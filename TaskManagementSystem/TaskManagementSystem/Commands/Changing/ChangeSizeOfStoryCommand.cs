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
    public class ChangeSizeOfStoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeSizeOfStoryCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }
        //CommandParams should be:
        //[0] = string, storyTitle
        //[1] = string, new story size
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string storyTitle = this.CommandParameters[0];
            SizeType newSize = base.ParseSizeParameter(this.CommandParameters[1], "Size");

            var story = this.Repository.GetStory(storyTitle);
            if (story == null)
            {
                throw new InvalidStoryException($"Story with title '{storyTitle}' does not exist.");
            }

            string oldSize = story.Size.ToString();

            this.Repository.UpdateStorySize(story, newSize);


            return $"Priority of story '{storyTitle}' was changed from '{oldSize}' to '{newSize}'.";

        }
    }
}
