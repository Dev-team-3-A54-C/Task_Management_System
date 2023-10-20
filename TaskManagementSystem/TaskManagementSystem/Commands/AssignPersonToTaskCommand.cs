using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Commands
{
    public class AssignPersonToTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public AssignPersonToTaskCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
            
        }

        //CommandParams should be:
        //[0] = string, personName
        //[1] = string, taskName
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string personName = this.CommandParameters[0];
            string taskName = this.CommandParameters[1];

            var person = this.Repository.GetMember(personName);

            var task = this.Repository.GetTask(taskName);

            var type = task.GetType();
            var isAssignable = typeof(IHasAssignee).IsAssignableFrom(type);

            if(isAssignable)
            {
                throw new InvalidUserInputException($"There is no assignable task with name '{taskName}'.");
            }

            //Not sure if it works properly, needs testing
            var assignableTask = (IHasAssignee)task;
            assignableTask.AssignMember(person);

            
            return $"{personName} was assigned to task (bug/story) '{taskName}'";

        }
    }
}
