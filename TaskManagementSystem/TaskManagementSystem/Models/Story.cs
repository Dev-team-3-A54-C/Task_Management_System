using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Story : Task, IStory
    {
        public Story(int id, string title, string description, SizeType size)
            : base(id, title, description)
        {
            Size = size;
            Status = StoryStatusType.NotDone;
        }

        public SizeType Size { get; private set; }

        public StoryStatusType Status { get; private set; }

        public PriorityType Priority { get; private set; }

        public Member Assignee => throw new NotImplementedException();

        public override void AdvanceStatus()
        {
            if (Status != StoryStatusType.Done)
            {
                var prevStatus = Status;
                Status++;
                // Todo
                //this.AddEventLog($"Story's status changed from {prevStatus} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Story's status already set to Done");
            }
        }

        public override void ReverseStatus()
        {
            if (Status != StoryStatusType.NotDone)
            {
                var prevStatus = Status;
                Status--;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Story's status already set to NotDone");
            }
        }

        public void IncreasePriority()
        {
            if (Priority != PriorityType.High)
            {
                var prev = Priority;
                Priority++;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Verified");
            }
        }

        public void DecreasePriority()
        {
            if (Priority != PriorityType.Low)
            {
                var prev = Priority;
                Priority--;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Verified");
            }
        }

        public void IncreaseSize()
        {
            if (Size != SizeType.Large)
            {
                var prev = Size;
                Size++;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Verified");
            }
        }

        public void DecreaseSize()
        {
            if (Size != SizeType.Small)
            {
                var prev = Size;
                Size--;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Verified");
            }
        }
    }
}
