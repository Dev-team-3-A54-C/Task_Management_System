using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Adding
{
    public class AddCommentToTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public AddCommentToTaskCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {            
        }

        //CommandParams should be:
        //[0] = string, commentMessage
        //[1] = string, commentAuthor
        //[2] = string, taskTitle
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string commentMessage = this.CommandParameters[0];
            string commentAuthor = this.CommandParameters[1];
            string taskTitle = this.CommandParameters[2];

            var comment = this.Repository.CreateComment(commentMessage, commentAuthor);

            var task = this.Repository.GetTask(taskTitle);

            this.Repository.AddCommentToTask(comment, task);

            return $"Comment with author '{commentAuthor}' was added to task '{taskTitle}'.";
        }
    }
}
