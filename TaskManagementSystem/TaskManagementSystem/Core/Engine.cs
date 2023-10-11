using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Core
{
    public class Engine : IEngine
    {
        private const string EmptyCommandError = "Command cannot be empty.";
        private const string TerminationCommand = "Exit";
        private const string ReportSeparator = "####################";

        private readonly ICommandFactory commandFactory;
        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }
        public void Start()
        {
            while(true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if(input == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }

                    if(input.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;   
                    }

                    ICommand command = commandFactory.Create(input);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                catch(Exception exception)
                {
                    if (!string.IsNullOrEmpty(exception.Message))
                    {
                        Console.WriteLine(exception.Message);
                    }
                    else
                    {
                        Console.WriteLine(exception);
                    }
                    Console.WriteLine(ReportSeparator);
                }
            }

        }
    }
}
