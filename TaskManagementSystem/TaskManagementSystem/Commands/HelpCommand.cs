using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Commands.Enums;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands
{
    public class HelpCommand : BaseCommand
    {
        public HelpCommand(IRepository repository) : base(repository)
        {
            
        }

        //Print all available commands for use
        public override string Execute()
        {
            StringBuilder commandsString = new StringBuilder();

            commandsString.AppendLine();

            for (int i=0; i < (int)CommandType.Help; i++)
            {
                commandsString.AppendLine($"{(CommandType)i}Command,");
            }
            
            commandsString.AppendLine();

            return commandsString.ToString();
        }
    }
}
