using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowTeamActivityCommand : BaseCommand
    {
        public ShowTeamActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, teamName
        public override string Execute()
        {
            string teamName = CommandParameters[0];

            var team = this.Repository.GetTeam(teamName);
            if (team == null)
            {
                throw new InvalidTeamException($"Team with the name '{teamName}' does not exist.");
            }

            StringBuilder output = new StringBuilder();

            //foreach (var record in team.EventLog)
            //{
            //    output.Append(record.ToString());
            //}

            return output.ToString();
        }
    }
}
