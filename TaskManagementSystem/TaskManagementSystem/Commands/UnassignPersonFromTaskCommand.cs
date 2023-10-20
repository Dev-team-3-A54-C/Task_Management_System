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

            var task = this.Repository.GetTask(taskName);

            var assignableTask = this.Repository.Tasks.OfType<IHasAssignee>().FirstOrDefault(t => t.Title == taskName);            

            if (assignableTask == null)
            {
                throw new InvalidUserInputException($"There is no assignable task with name '{taskName}'.");
            }

            assignableTask.UnassignMember();

            return $"Task (bug/story) '{taskName}' no longer has an assignee.'";

        }
    }
}
