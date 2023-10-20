using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Board : IBoard
    {
        private string name = "";
        private const int NameMinValue = 5;
        private const int NameMaxValue = 10;
        private const string NameExceptionMessage = "Name of the board must be between {0} and {1} symbols";

        private IList<ITask> tasks = new List<ITask>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Board(string name)
        {
            Name = name;
            AddEventToLog($"Board with name \"{Name}\" created");
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
                throw new DuplicateItemException($"Task with name \"{task.Title}\" already exist in the board \"{Name}\"");

            tasks.Add(task);
            AddEventToLog($"Task \"{task.Title}\" added to board \"{Name}\"");
        }

        public void RemoveTask(ITask task)
        {
            if (!tasks.Contains(task))
                throw new ArgumentException($"No such item with title \"{task.Title}\" and id \"{task.Id}\" exists inside board \"{Name}\"");

            tasks.Remove(task);
            AddEventToLog($"Task \"{task.Title}\" removed from board \"{Name}\"");
        }

        public void AddEventToLog(string description)
        {
            eventLog.Add(new Event(description));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"--- Board: {Name} ---");
            stringBuilder.AppendLine($"     Tasks:");

            foreach (ITask task in tasks)
            {
                stringBuilder.AppendLine($"      {task.Title}");
            }

            return stringBuilder.ToString();
        }
    }
}
