using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowAllTeamBoardsCommand : BaseCommand
    {
        public ShowAllTeamBoardsCommand(IList<string> commandParameters,IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, teamName
        public override string Execute()
        {
            string teamName = CommandParameters[0];

            var team = this.Repository.GetTeam(teamName);


            if (team.Boards.Count == 0)
            {
                return $"There are no boards added in team '{teamName}'.";
            }

            StringBuilder output = new StringBuilder();

            foreach (var board in team.Boards)
            {
                output.AppendLine(board.ToString());
            }

            return output.ToString();
        }
    }
}
