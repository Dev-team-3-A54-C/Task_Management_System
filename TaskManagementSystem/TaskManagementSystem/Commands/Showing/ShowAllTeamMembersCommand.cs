using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowAllTeamMembersCommand : BaseCommand
    {
        public ShowAllTeamMembersCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, teamName
        public override string Execute()
        {
            string teamName = CommandParameters[0];

            var team = this.Repository.GetTeam(teamName);


            if (team.Members.Count == 0)
            {
                return $"There are no members in team '{teamName}'.";
            }

            StringBuilder output = new StringBuilder();

            foreach (var member in team.Members)
            {
                output.AppendLine(member.ToString());
            }

            return output.ToString();
        }
    }
}
