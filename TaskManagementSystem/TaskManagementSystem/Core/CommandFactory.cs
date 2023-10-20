using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Commands.Adding;
using TaskManagementSystem.Commands.Changing;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Commands.Creating;
using TaskManagementSystem.Commands.Enums;
using TaskManagementSystem.Commands.Listing.Bugs;
using TaskManagementSystem.Commands.Listing.Feedbacks;
using TaskManagementSystem.Commands.Listing.Stories;
using TaskManagementSystem.Commands.Listing.Tasks;
using TaskManagementSystem.Commands.Showing;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;
        public CommandFactory(IRepository repo)
        {
            this.repository = repo;
        }
        public ICommand Create(string input)
        {
            CommandType commandType = ParseCommandType(input);
            List<string> commandParameters = this.ExtractCommandParameters(input);

            switch (commandType)
            {
                case CommandType.AddCommentToTask:
                    return new AddCommentToTaskCommand(commandParameters, repository);
                case CommandType.AddPersonToTeam:
                    return new AddPersonToTeamCommand(commandParameters, repository);
                case CommandType.ChangePriorityOfBug:
                    return new ChangePriorityOfBugCommand(commandParameters, repository);
                case CommandType.ChangePriorityOfStory:
                    return new ChangePriorityOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeRatingOfFeedback:
                    return new ChangeRatingOfFeedbackCommand(commandParameters, repository);
                case CommandType.ChangeSeverityOfBug:
                    return new ChangeSeverityOfBugCommand(commandParameters, repository);
                case CommandType.ChangeSizeOfStory:
                    return new ChangeSizeOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfBug:
                    return new ChangeStatusOfBugCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfStory:
                    return new ChangeStatusOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfFeedback:
                    return new ChangeStatusOfFeedbackCommand(commandParameters, repository);
                case CommandType.CreateNewBoardInTeam:
                    return new CreateNewBoardInTeamCommand(commandParameters, repository);
                case CommandType.CreateNewBugInBoard:
                    return new CreateNewBugInBoardCommand(commandParameters, repository);
                case CommandType.CreateNewFeedbackInBoard:
                    return new CreateNewFeedbackInBoardCommand(commandParameters, repository);
                case CommandType.CreateNewPerson:
                    return new CreateNewPersonCommand(commandParameters, repository);
                case CommandType.CreateNewStoryInBoard:
                    return new CreateNewStoryInBoardCommand(commandParameters, repository);
                case CommandType.CreateNewTeam:
                    return new CreateNewTeamCommand(commandParameters, repository);
                case CommandType.ListAllBugs:
                    return new ListAllBugsCommand(repository);
                case CommandType.ListAllBugsWithAssignee:
                    return new ListAllBugsWithAssignee(commandParameters, repository);
                case CommandType.ListAllBugsWithStatus:
                    return new ListAllBugsWithStatus(commandParameters, repository);
                case CommandType.ListAllFeedbacks:
                    return new ListAllFeedbacksCommand(repository);
                case CommandType.ListAllFeedbacksWithStatus:
                    return new ListAllFeedbacksWithStatus(commandParameters, repository);
                case CommandType.ListAllStories:
                    return new ListAllStoriesCommand(repository);
                case CommandType.ListAllStoriesWithAssignee:
                    return new ListAllStoriesWithAssignee(commandParameters, repository);
                case CommandType.ListAllStoriesWithStatus:
                    return new ListAllStoriesWithStatus(commandParameters, repository);
                case CommandType.ListAllTasks:
                    return new ListAllTasksCommand(repository);
                case CommandType.ListAllTasksWithAssignee:
                    return new ListAllTasksWithAssigneeCommand(commandParameters, repository);
                case CommandType.ListAllTasksWithTitle:
                    return new ListAllTasksWithTitle(commandParameters, repository);
                case CommandType.AssignPersonToTask:
                    return new AssignPersonToTaskCommand(commandParameters, repository);
                case CommandType.UnassignPersonFromTask:
                    return new UnassignPersonFromTaskCommand(commandParameters, repository);
                case CommandType.ShowAllPeople:
                    return new ShowAllPeopleCommand(repository);
                case CommandType.ShowAllTeamBoards:
                    return new ShowAllTeamBoardsCommand(commandParameters, repository);
                case CommandType.ShowAllTeamMembers:
                    return new ShowAllTeamMembersCommand(commandParameters, repository);
                case CommandType.ShowAllTeams:
                    return new ShowAllTeamsCommand(repository);
                case CommandType.ShowBoardActivity:
                    return new ShowBoardActivityCommand(commandParameters, repository);
                case CommandType.ShowPersonActivity:
                    return new ShowPersonActivityCommand(commandParameters, repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParameters, repository);
                case CommandType.Help:
                    return new HelpCommand(repository);
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }

        }

        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }

        private List<string> ExtractCommandParameters(string commandLine)
        {
            //todo
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
