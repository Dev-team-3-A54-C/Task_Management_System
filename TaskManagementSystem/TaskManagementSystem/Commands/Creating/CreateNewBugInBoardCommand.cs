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
    public class CreateNewBugInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;

        public CreateNewBugInBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {           
        }

        //CommandParams should be:
        //[0] = string, bugTitle
        //[1] = string, bugDescription
        //[2] = List<string>, stepsToReproduceBug
        //[3] = bugPriority, enum from PriorityType
        //[4] = bugSeverity, enum from SeverityType

        //[5] = boardName, string
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string bugTitle = CommandParameters[0];
            string bugDescription = CommandParameters[1];
            List<string> stepsToReproduceBug = CommandParameters[2].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            PriorityType bugPriority = base.ParsePriorityParameter(CommandParameters[3],"Priority");
            SeverityType bugSeverity = base.ParseSeverityParameter(CommandParameters[4], "Severity");
            //BugStatusType bugStatus = base.ParseBugStatusParameter(CommandParameters[5], "Bug Status");
            string boardName = CommandParameters[5];

            var newBug = this.Repository.CreateBug(bugTitle, bugDescription, stepsToReproduceBug, bugPriority, bugSeverity);

            var board = this.Repository.GetBoard(boardName);
            if(board == null)
            {
                throw new InvalidBoardException($"Board with name '{boardName}' does not exist");
            }

            board.AddTask(newBug);

            return $"New bug with title '{bugTitle}' was created and added to board '{boardName}'";
        }

    }
}
