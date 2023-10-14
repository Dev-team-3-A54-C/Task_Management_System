using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Changing
{
    public class ChangeSeverityOfBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeSeverityOfBugCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, bugTitle
        //[1] = string, new bug Severity
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string bugTitle = this.CommandParameters[0];
            SeverityType newSeverity = base.ParseSeverityParameter(this.CommandParameters[1], "Severity");

            var bug = this.Repository.GetBug(bugTitle);
            if (bug == null)
            {
                throw new InvalidBugException($"Bug with title '{bugTitle}' does not exist.");
            }

            string oldSeverity = bug.Severity.ToString();

            bug.SetSeverity(newSeverity);

            return $"Priority of bug '{bugTitle}' was changed from '{oldSeverity}' to '{newSeverity}'.";

        }
    }
}
