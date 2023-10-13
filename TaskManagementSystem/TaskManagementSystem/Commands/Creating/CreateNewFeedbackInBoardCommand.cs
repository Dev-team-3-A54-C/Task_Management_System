using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Creating
{
    public class CreateNewFeedbackInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 4;

        public CreateNewFeedbackInBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters,repository)
        {
               
        }

        //CommandParams should be:
        //[0] = string, feedbackTitle
        //[1] = string, feedbackDescription
        //[2] = int, feedbackRating,
        //[3] = boardName, string
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string feedbackTitle = CommandParameters[0];
            string feedbackDescription = CommandParameters[1];
            int feedbackRating = base.ParseIntParameter(CommandParameters[2], "Rating");

            string boardName = CommandParameters[3];

            var newFeedback = this.Repository.CreateFeedback(feedbackTitle,feedbackDescription, feedbackRating);

            var board = this.Repository.GetBoard(boardName);
            if (board == null)
            {
                throw new InvalidBoardException($"Board with name '{boardName}' does not exist");
            }

            board.AddTask(newFeedback);

            return $"New feedback with title '{feedbackTitle}' was created and added to board '{boardName}'";
        }
    }
}
