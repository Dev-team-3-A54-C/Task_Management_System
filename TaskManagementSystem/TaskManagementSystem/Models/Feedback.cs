﻿using System;
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
            TaskType = TaskType.Feedback;
            base.AddEventToLog($"Feedback with \"{Title}\" created");
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
            ValidationHelpers.ValidationHelper.ValidateIfIntIsNegative(rating, "Rating cannot be negative");

            int oldRating = Rating;
            Rating = rating;
            base.AddEventToLog($"The rating of the feedback \"{Title}\" changed from \"{oldRating}\" to \"{Rating}\"");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"     Rating: {Rating}");
            stringBuilder.AppendLine($"     Status: {Status}");

            return stringBuilder.ToString();
        }
    }
}
