using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Bug : Task, IBug
    {
        
        public Bug(int id, string title, string description, PriorityType priority, SeverityType severity)
            : base(id, title, description)
        {
            Priority = priority;
            Status = BugStatusType.Active;
        }

        public IList<string> StepsToReproduce => throw new NotImplementedException();

        public PriorityType Priority { get; private set; }

        public Member Assignee => throw new NotImplementedException();

        public SeverityType Severity { get; private set; }

        public BugStatusType Status { get; private set; }


        public override void AdvanceStatus()
        {
            if (Status != BugStatusType.Fixed)
            {
                Status = BugStatusType.Fixed;
                // Todo
                //this.AddEventLog("The status of item with ID 42 switched from Active to Done.");
            }
            else
            {
                // Todo
                //this.AddEventLog("Bug status already Fixed");
            }
        }

        public override void ReverseStatus()
        {
            if (Status != BugStatusType.Active)
            {
                Status = BugStatusType.Active;
                // Todo
                //this.AddEventLog("Bug status set to Active");
            }
            else
            {
                // Todo
                //this.AddEventLog("Bug status already Active");
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

        public void IncreaseSeverity()
        {
            if (Severity != SeverityType.Minor)
            {
                var prev = Severity;
                Severity++;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Verified");
            }
        }

        public void LowerSeverity()
        {
            if (Severity != SeverityType.Critical)
            {
                var prev = Severity;
                Severity--;
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
