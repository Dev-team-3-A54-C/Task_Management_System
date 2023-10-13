using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Commands.Adding;
using TaskManagementSystem.Commands.Changing;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Commands.Creating;
using TaskManagementSystem.Commands.Enums;
using TaskManagementSystem.Commands.Listing;
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
                case CommandType.AddCommentToTaskCommand:
                    return new AddCommentToTaskCommand();
                case CommandType.AddPersonToTeamCommand:
                    return new AddPersonToTeamCommand();
                case CommandType.ChangePriorityOfBugCommand:
                    return new ChangePriorityOfBugCommand();
                case CommandType.ChangePriorityOfStoryCommand:
                    return new ChangePriorityOfStoryCommand();
                case CommandType.ChangeRatingOfFeedbackCommand:
                    return new ChangeRatingOfFeedbackCommand();
                case CommandType.ChangeSeverityOfBugCommand:
                    return new ChangeSeverityOfBugCommand();
                case CommandType.ChangeSizeOfStoryCommand:
                    return new ChangeSizeOfStoryCommand();
                case CommandType.ChangeStatusOfBugCommand:
                    return new ChangeStatusOfBugCommand();
                case CommandType.ChangeStatusOfStoryCommand:
                    return new ChangeStatusOfStoryCommand();
                case CommandType.ChangeStatusOfFeedbackCommand:
                    return new ChangeStatusOfFeedbackCommand();
                case CommandType.CreateNewBoardItemCommand:
                    return new CreateNewBoardItemCommand();
                case CommandType.CreateNewBugInBoardCommand:
                    return new CreateNewBugInBoardCommand();
                case CommandType.CreateNewFeedbackInBoardCommand:
                    return new CreateNewFeedbackInBoardCommand();
                case CommandType.CreateNewPersonCommand:
                    return new CreateNewPersonCommand();
                case CommandType.CreateNewStoryInBoardCommand:
                    return new CreateNewStoryInBoardCommand();
                case CommandType.CreateNewTeamCommand:
                    return new CreateNewTeamCommand();
                case CommandType.ListAllBugsCommand:
                    return new ListAllBugsCommand();
                case CommandType.ListAllFeedbacksCommand:
                    return new ListAllFeedbacksCommand();
                case CommandType.ListAllStoriesCommand:
                    return new ListAllStoriesCommand();
                case CommandType.ListAllTasksCommand:
                    return new ListAllTasksCommand();
                case CommandType.ListAllTasksWithAssigneeCommand:
                    return new ListAllTasksWithAssigneeCommand();
                case CommandType.AssignPersonToTaskCommand:
                    return new AssignPersonToTaskCommand();
                case CommandType.UnassignPersonFromTaskCommand:
                    return new UnassignPersonFromTaskCommand();
                case CommandType.ShowAllPeopleCommand:
                    return new ShowAllPeopleCommand();
                case CommandType.ShowAllTeamBoardsCommand:
                    return new ShowAllTeamBoardsCommand();
                case CommandType.ShowAllTeamMembersCommand:
                    return new ShowAllTeamMembersCommand();
                case CommandType.ShowAllTeamsCommand:
                    return new ShowAllTeamsCommand();
                case CommandType.ShowBoardActivityCommand:
                    return new ShowBoardActivityCommand();
                case CommandType.ShowPersonActivityCommand:
                    return new ShowPersonActivityCommand();
                case CommandType.ShowTeamActivityCommand:
                    return new ShowTeamActivityCommand();
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
