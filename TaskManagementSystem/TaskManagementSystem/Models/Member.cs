using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Member : HasName, IMember
    {
        private const int NameMinValue = 5;
        private const int NameMaxValue = 15;
        private const string NameExceptionMessage = "Name";

        private IList<ITask> tasks = new List<ITask>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Member(string name)
            : base(name, NameMinValue, NameMaxValue, NameExceptionMessage)
        {
            AddEventToLog($"Member with name \"{base.Name}\" created");
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
            tasks.Add(task);
            AddEventToLog($"Task \"{task.Title}\" added to {base.Name}'s list");
        }

        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
            AddEventToLog($"Task \"{task.Title}\" remvoed from {base.Name}'s list");
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
