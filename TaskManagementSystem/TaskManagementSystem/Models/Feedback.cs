using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Feedback : Task, IFeedback
    {

        public Feedback(int id, string title, string description, int rating)
            : base(id, title, description)
        {
            Rating = rating;
            Status = FeedbackStatusType.New;
        }

        public int Rating { get; private set; }

        public FeedbackStatusType Status { get; private set; }

        public override void AdvanceStatus()
        {
            if (Status != FeedbackStatusType.Done)
            {
                var prev = Status;
                Status++;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                // this.AddEventLog("Task status already Verified");
            }
        }

        public override void ReverseStatus()
        {
            if (Status != FeedbackStatusType.New)
            {
                var prev = Status;
                Status--;
                // Todo
                //this.AddEventLog($"Task changed from {prev} to {this.Status}");
            }
            else
            {
                // Todo
                //this.AddEventLog("Task status already Todo");
            }
        }

        public void SetRating(int newRating)
        {
            Rating = newRating;
        }
    }
}
