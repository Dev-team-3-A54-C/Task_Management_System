using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Stories
{
    public class ListAllStoriesWithAssignee : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ListAllStoriesWithAssignee(IList<string> commandParameters, IRepository repository) 
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

            IList<IStory> stories = Repository.FilterStoriesByAssignee(assignee);

            StringBuilder sb = new StringBuilder();
            foreach (var item in stories)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
