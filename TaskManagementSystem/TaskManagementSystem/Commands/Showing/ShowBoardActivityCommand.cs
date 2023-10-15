using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowBoardActivityCommand : BaseCommand
    {
        public ShowBoardActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, boardName
        public override string Execute()
        {
            string boardName = CommandParameters[0];

            var board = this.Repository.GetBoard(boardName);
            if (board == null)
            {
                throw new InvalidBoardException($"Board with the name '{boardName}' does not exist.");
            }

            StringBuilder output = new StringBuilder();

            foreach (var record in board.EventLog)
            {
                output.Append(record.ToString());
            }

            return output.ToString();
        }
    }
}
