using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.ValidationHelpers;

namespace TaskManagementSystem.Models
{
    public abstract class Task : ITask
    {
        private int id;
        private string title;
        private string description;

        private const int TitleMinValue = 10;
        private const int TitleMaxValue = 50;
        private const string TitleExceptionMessage = "Title must be between {0} and {1} symbols";

        private const int DescriptionMinValue = 10;
        private const int DescriptionMaxValue = 500;
        private const string DescriptionExceptionMessage = "Description must be between {0} and {1} symbols";

        private IList<IComment> comments = new List<IComment>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        public int Id
        {
            get => this.id;
            private set
            {
                this.id = value;
            }
        }

        public string Title
        {
            get => this.title;
            private set
            {
                ValidationHelper.ValidateStringLength(value, TitleMinValue, TitleMaxValue, TitleExceptionMessage);
                this.title = value;
            }
        }

        public string Description
        {
            get => this.description;
            private set
            {
                ValidationHelper.ValidateStringLength(value, DescriptionMinValue, DescriptionMaxValue, DescriptionExceptionMessage);
                this.description = value;
            }
        }

        public IList<IComment> Comments
        {
            get => new List<IComment>(comments);
        }

        public IList<IEvent> EventLog
        {
            get => new List<IEvent>(eventLog);
        }

        public abstract void AdvanceStatus();

        public abstract void ReverseStatus();

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
        }

        public void AddEventToLog(string description)
        {
            eventLog.Add(new Event(description));
        }

        public override string ToString()
        {
            return "todo";
            // Todo     title, priority, status
        }
    }
}
