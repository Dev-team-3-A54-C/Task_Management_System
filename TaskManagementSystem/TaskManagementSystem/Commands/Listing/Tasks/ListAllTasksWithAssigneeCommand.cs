using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Tasks
{
    public class ListAllTasksWithAssigneeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public ListAllTasksWithAssigneeCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {

        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}.");
            }

            string name = CommandParameters[0];
            IMember member = Repository.GetMember(name);

            IList<ITask> tasksWithAssignee = Repository.FilterTasksByAssignee(member);

            StringBuilder sb = new StringBuilder();
            foreach (var item in tasksWithAssignee)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
