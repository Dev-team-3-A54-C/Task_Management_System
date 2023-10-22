using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowAllTeamsCommand : BaseCommand
    {
        public ShowAllTeamsCommand(IRepository repository) : base(repository)
        {

        }

        //CommandParams should be none
        public override string Execute()
        {
            var teams = this.Repository.Teams;

            if (teams.Count == 0)
            {
                return $"There are no registered teams.";
            }

            StringBuilder output = new StringBuilder();

            foreach (var team in teams)
            {
                output.AppendLine(team.ToString());
            }

            return output.ToString();
        }
    }
}
