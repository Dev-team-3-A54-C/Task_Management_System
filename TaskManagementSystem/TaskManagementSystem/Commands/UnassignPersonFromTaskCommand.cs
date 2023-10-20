using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

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
            var task = this.Repository.GetTask(taskName);

            var type = task.GetType();
            var isAssignable = typeof(IHasAssignee).IsAssignableFrom(type);

            if (isAssignable)
            {
                throw new InvalidUserInputException($"There is no assignable task with name '{taskName}'.");
            }
            //Not sure if it works right, needs testing
            var assignableTask = (IHasAssignee)task;
            assignableTask.UnassignMember();

            return $"Task (bug/story) '{taskName}' no longer has an assignee.'";

        }
    }
}
