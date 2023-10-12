using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Board : HasName, IBoard
    {
        private const int NameMinValue = 5;
        private const int NameMaxValue = 10;
        private const string NameExceptionMessage = "Name of the board must be between {0} and {1} symbols";

        private IList<ITask> tasks = new List<ITask>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Board(string name)
            : base(name, NameMinValue, NameMaxValue, NameExceptionMessage)
        {
            AddEventToLog($"Board with name \"{base.Name}\" created");
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
            AddEventToLog($"Task \"{task.Title}\" added to board \"{base.Name}\"");
        }

        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
            AddEventToLog($"Task \"{task.Title}\" removed from board \"{base.Name}\"");
        }

        public void AddEventToLog(string description)
        {
            eventLog.Add(new Event(description));
        }

        public override string ToString()
        {
            return "todo";
            // Todo
        }
    }
}
