using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Creating
{
    public class CreateNewBoardInTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public CreateNewBoardInTeamCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {                
        }

        //CommandParams should be:
        //[0] = string, boardName
        //[1] = string, teamName

        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];

            var team = this.Repository.GetTeam(teamName);
            if(team == null)
            {
                throw new InvalidTeamException($"Team with the name '{teamName}' does not exist.");
            }

            var board = this.Repository.CreateBoard(boardName);

            team.AddBoard(board);

            return $"Board with name '{boardName}' was created and added to '{teamName}'";
        }
    }
}
