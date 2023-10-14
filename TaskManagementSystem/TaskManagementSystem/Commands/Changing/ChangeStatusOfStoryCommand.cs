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
            if (story == null)
            {
                throw new InvalidStoryException($"Story with title '{storyTitle}' does not exist.");
            }

            string oldStatus = story.Status.ToString();

            ExecuteHelper(story, newStatus);

            return $"Status of story '{storyTitle}' was changed from '{oldStatus}' to '{newStatus}'.";

        }

        private void ExecuteHelper(IStory story, StoryStatusType newStatus)
        {
            //If statusDiff is > 0 then we need to RevertStatus by abs statusDiff times
            //else if statusDiff is < 0 then we need to AdvanceStatus by statusDiff times
            //else (statusDiff == 0) that means the new status is the same as the old one

            int statusDiff = (int)story.Status - (int)newStatus;

            if (statusDiff > 0)
            {
                while (statusDiff != 0)
                {
                    story.ReverseStatus();
                    statusDiff--;
                }
            }
            else if (statusDiff < 0)
            {
                while (statusDiff != 0)
                {
                    story.AdvanceStatus();
                    statusDiff++;
                }
            }

            //Clarification needed when new Status is same as old status
        }
    }
}
