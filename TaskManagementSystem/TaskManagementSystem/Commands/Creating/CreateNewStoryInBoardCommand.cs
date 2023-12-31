﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Creating
{
    public class CreateNewStoryInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;
        public CreateNewStoryInBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
            
        }

        //CommandParams should be:
        //[0] = string, storyTitle
        //[1] = string, storyDescription
        //[2] = PriorityType, storyPriority,
        //[3] = StorySize, storySize
        //[4] = string, boardName
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string storyTitle = CommandParameters[0];
            string storyDescription = CommandParameters[1];
            PriorityType storyPriority = base.ParsePriorityParameter(this.CommandParameters[2], "Priority");
            SizeType storySize = base.ParseSizeParameter(this.CommandParameters[3], "Size");

            string boardName = CommandParameters[4];

            var newStory = this.Repository.CreateStory(storyTitle,storyDescription,storySize,storyPriority);

            var board = this.Repository.GetBoard(boardName);

            board.AddTask(newStory);

            return $"New story with title '{storyTitle}' was created and added to board '{boardName}'";
        }
    }
}
