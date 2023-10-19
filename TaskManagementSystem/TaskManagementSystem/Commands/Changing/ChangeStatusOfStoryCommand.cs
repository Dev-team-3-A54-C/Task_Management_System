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
    public class ChangeStatusOfStoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStatusOfStoryCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, storyTitle
        //[1] = string, new story Status
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string storyTitle = this.CommandParameters[0];
            StoryStatusType newStatus = base.ParseStoryStatusParameter(this.CommandParameters[1], "Status");

            var story = this.Repository.GetStory(storyTitle);

            string oldStatus = story.Status.ToString();

            this.Repository.UpdateStoryStatus(story, newStatus);


            return $"Status of story '{storyTitle}' was changed from '{oldStatus}' to '{newStatus}'.";

        }
       
    }
}
