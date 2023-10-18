using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands.Listing.Bugs
{
    public class ListAllBugsWithAssignee : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ListAllBugsWithAssignee(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}.");
            }

            string assigneeName = CommandParameters[0];
            IMember assignee = Repository.GetMember(assigneeName);

            IList<IBug> bugs = Repository.FilterBugsByAssignee(assignee);

            StringBuilder sb = new StringBuilder();
            foreach (var item in bugs)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
