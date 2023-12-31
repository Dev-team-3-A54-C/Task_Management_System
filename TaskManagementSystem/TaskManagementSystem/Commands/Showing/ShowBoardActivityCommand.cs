﻿using System;
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

            StringBuilder output = new StringBuilder();

            foreach (var record in board.EventLog)
            {
                output.AppendLine(record.ToString());
            }

            return output.ToString();
        }
    }
}
