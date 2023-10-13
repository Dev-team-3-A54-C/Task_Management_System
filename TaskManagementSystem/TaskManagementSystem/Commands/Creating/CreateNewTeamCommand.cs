using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Creating
{
    public class CreateNewTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public CreateNewTeamCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        //CommandParams should be:
        //[0] = string, teamName


        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string teamName = this.CommandParameters[0];

            this.Repository.CreateTeam(teamName);

            return $"Team with the name {teamName} was created!";
        }
    }
}
