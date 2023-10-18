using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class UnassignPersonFromTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public UnassignPersonFromTaskCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, taskName
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string taskName = this.CommandParameters[0];

            //Should rewrite in future

            var bug = this.Repository.GetBug(taskName);
            var story = this.Repository.GetStory(taskName);
            if (bug == null && story == null)
            {
                throw new InvalidUserInputException($"Taks, that can have an assignee, with the name '{taskName}' does not exist.");
            }

            if (bug is not null)
            {
                bug.UnassignMember();
                return $"Bug '{taskName}' no longer has an assignee.'";
            }

            story.UnassignMember();
            return $"Story '{taskName}' no longer has an assignee.'";

        }
    }
}
