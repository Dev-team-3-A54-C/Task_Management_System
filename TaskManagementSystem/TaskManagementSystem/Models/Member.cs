using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Member : IMember
    {
        private string name = "";
        private const int NameMinValue = 5;
        private const int NameMaxValue = 15;
        private const string NameExceptionMessage = "Name of the member must be between {0} and {1} symbols";

        private IList<ITask> tasks = new List<ITask>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Member(string name)
        {
            Name = name;
            AddEventToLog($"Member with name \"{Name}\" created");
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidationHelpers.ValidationHelper.ValidateStringLength(value, NameMinValue, NameMaxValue, NameExceptionMessage);
                this.name = value;
            }
        }

        public IList<ITask> Tasks
        {
            get => new List<ITask>(tasks);
        }

        public IList<IEvent> EventLog
        {
            get => new List<IEvent>(eventLog);
        }

        public void AddTask(ITask task)
        {
            if (tasks.Contains(task))
                throw new DuplicateItemException($"Task with name \"{task.Title}\" already assigned to the member \"{Name}\"");

            tasks.Add(task);
            AddEventToLog($"Task \"{task.Title}\" added to {Name}'s list");
        }

        public void RemoveTask(ITask task)
        {
            if (!tasks.Contains(task))
                throw new ArgumentException($"No such item with title \"{task.Title}\" and id \"{task.Id}\" is assigned for member \"{Name}\"");

            tasks.Remove(task);
            AddEventToLog($"Task \"{task.Title}\" remvoed from {Name}'s list");
        }

        public void AddEventToLog(string description)
        {
            eventLog.Add(new Event(description));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"--- Member: {Name} ---");
            stringBuilder.AppendLine($"     Tasks:");

            foreach (ITask task in tasks)
            {
                stringBuilder.AppendLine($"      {task.Title}");
            }

            return stringBuilder.ToString();
        }

    }
}
