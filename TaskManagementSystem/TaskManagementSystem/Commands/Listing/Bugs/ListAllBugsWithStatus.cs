using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Bugs
{
    public class ListAllBugsWithStatus : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ListAllBugsWithStatus(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}.");
            }

            BugStatusType status = base.ParseBugStatusParameter(CommandParameters[0], "BugStatus");

            IList<IBug> bugs = Repository.FilterBugsByStatus(status);

            StringBuilder sb = new StringBuilder();
            foreach (var item in bugs)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
