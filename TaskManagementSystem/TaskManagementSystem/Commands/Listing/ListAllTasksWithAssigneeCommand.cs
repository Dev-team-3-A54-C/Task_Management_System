using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands.Listing
{
    public class ListAllTasksWithAssigneeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        //ToDo
        public ListAllTasksWithAssigneeCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
            
        }
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            
            string name = this.CommandParameters[0];
            IMember member = Repository.GetMember(name);

            IList<IBug> tasksWithAssignee = this.Repository.Tasks
                .Where(x => x.GetType() == typeof(Story) || x.GetType() == typeof(Bug))
                .Select(x => (IBug)x)
                .Where(x => x.Assignee == member)
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in tasksWithAssignee)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
