using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands.Listing.Tasks
{
    public class ListAllTasksWithTitle : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ListAllTasksWithTitle(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }
            
            string title = CommandParameters[0];

            IList<ITask> tasks = Repository.FilterTasksByTitle(title);

            StringBuilder sb = new StringBuilder();
            foreach (ITask task in tasks)
            {
                sb.AppendLine(task.ToString());
            }

            return sb.ToString();
        }
    }
}
