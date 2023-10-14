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
    public class ChangePriorityOfStoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangePriorityOfStoryCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, storyTitle
        //[1] = string, new story priority
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string storyTitle = this.CommandParameters[0];
            PriorityType priority = base.ParsePriorityParameter(this.CommandParameters[1], "Priority");

            var story = this.Repository.GetStory(storyTitle);
            if (story == null)
            {
                throw new InvalidStoryException($"Story with title '{storyTitle}' does not exist.");
            }

            string oldPriority = story.Priority.ToString();

            story.SetPriority(priority);

            return $"Priority of story '{storyTitle}' was changed from '{oldPriority}' to '{priority}'.";

        }
    }
}
