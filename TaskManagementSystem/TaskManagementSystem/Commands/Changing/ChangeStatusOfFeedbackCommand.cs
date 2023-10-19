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

            string oldStatus = feedback.Status.ToString();

            this.Repository.UpdateFeedbackStatus(feedback, newStatus);
            

            return $"Status of feedback '{feedbackTitle}' was changed from '{oldStatus}' to '{newStatus}'.";

        }
        
    }
}
