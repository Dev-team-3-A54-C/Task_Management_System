using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Changing
{
    public class ChangeStatusOfBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStatusOfBugCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, bugTitle
        //[1] = string, new bug Status
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string bugTitle = this.CommandParameters[0];
            BugStatusType newStatus = base.ParseBugStatusParameter(this.CommandParameters[1], "Status");

            var bug = this.Repository.GetBug(bugTitle);
            if (bug == null)
            {
                throw new InvalidBugException($"Bug with title '{bugTitle}' does not exist.");
            }

            string oldStatus = bug.Status.ToString();

            this.Repository.UpdateBugStatus(bug, newStatus);

            return $"Status of bug '{bugTitle}' was changed from '{oldStatus}' to '{newStatus}'.";

        }
        
    }
}
