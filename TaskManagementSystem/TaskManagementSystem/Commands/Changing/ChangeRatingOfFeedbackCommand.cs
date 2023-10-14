using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Changing
{
    public class ChangeRatingOfFeedbackCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeRatingOfFeedbackCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, feedbackTitle
        //[1] = string, new feedback rating
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string feedbackTitle = this.CommandParameters[0];
            int newRating = base.ParseIntParameter(this.CommandParameters[1], "Rating");

            var feedback = this.Repository.GetFeedback(feedbackTitle);
            if (feedback == null)
            {
                throw new InvalidStoryException($"Feedback with title '{feedbackTitle}' does not exist.");
            }

            int oldRating = feedback.Rating;

            feedback.SetRating(newRating);

            return $"Rating of feedback '{feedbackTitle}' was changed from '{oldRating}' to '{newRating}'.";

        }
    }
}
