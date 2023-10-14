using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Changing
{
    public class ChangeStatusOfFeedbackCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStatusOfFeedbackCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, feedbackTitle
        //[1] = string, new feedback Status
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string feedbackTitle = this.CommandParameters[0];
            FeedbackStatusType newStatus = base.ParseFeedbackStatusParameter(this.CommandParameters[1], "Status");

            var feedback = this.Repository.GetFeedback(feedbackTitle);
            if (feedback == null)
            {
                throw new InvalidFeedbackException($"Feedback with title '{feedbackTitle}' does not exist.");
            }

            string oldStatus = feedback.Status.ToString();

            ExecuteHelper(feedback, newStatus);

            return $"Status of feedback '{feedbackTitle}' was changed from '{oldStatus}' to '{newStatus}'.";

        }

        private void ExecuteHelper(IFeedback feedback, FeedbackStatusType newStatus)
        {
            //If statusDiff is > 0 then we need to RevertStatus by abs statusDiff times
            //else if statusDiff is < 0 then we need to AdvanceStatus by statusDiff times
            //else (statusDiff == 0) that means the new status is the same as the old one

            int statusDiff = (int)feedback.Status - (int)newStatus;

            if (statusDiff > 0)
            {
                while (statusDiff != 0)
                {
                    feedback.ReverseStatus();
                    statusDiff--;
                }
            }
            else if (statusDiff < 0)
            {
                while (statusDiff != 0)
                {
                    feedback.AdvanceStatus();
                    statusDiff++;
                }
            }

            //Clarification needed when new Status is same as old status
        }
    }
}
