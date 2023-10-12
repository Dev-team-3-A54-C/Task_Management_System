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
                FeedbackStatusType oldStatus = Status;
                Status++;
                base.AddEventToLog($"The status of the feedback \"{Title}\" changed from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot advance the status of the feedback \"{Title}\" more than \"{Status}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != FeedbackStatusType.New)
            {
                FeedbackStatusType oldStatus = Status;
                Status--;
                base.AddEventToLog($"The status of the feedback \"{Title}\" changed from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot reverse the status of the feedback \"{Title}\" more than \"{Status}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public void SetRating(int rating)
        {
            int oldRating = Rating;
            Rating = rating;
            base.AddEventToLog($"The rating of the feedback \"{Title}\" changed from \"{oldRating}\" to \"{Rating}\"");
        }

        public override string ToString()
        {
            return "todo";
            // Todo title, priority, status
        }
    }
}
