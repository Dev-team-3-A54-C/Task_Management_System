using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        CreateNewPersonCommand,
        ShowAllPeopleCommand,
        ShowPersonActivityCommand,
        CreateNewTeamCommand,
        ShowAllTeamsCommand,
        ShowTeamActivityCommand,
        AddPersonToTeamCommand,
        ShowAllTeamMembersCommand,
        CreateNewBoardItemCommand,
        ShowAllTeamBoardsCommand,
        ShowBoardActivityCommand,
        CreateNewBugInBoardCommand,
        CreateNewStoryInBoardCommand,
        CreateNewFeedbackInBoardCommand,
        ChangePriorityOfBugCommand,
        ChangeSeverityOfBugCommand,
        ChangeStatusOfBugCommand,
        ChangePriorityOfStoryCommand,
        ChangeStatusOfStoryCommand,
        ChangeSizeOfStoryCommand,
        ChangeRatingOfFeedbackCommand,
        ChangeStatusOfFeedbackCommand,
        AssignPersonToTaskCommand,
        UnassignPersonFromTaskCommand,
        ListAllTasksCommand,
        ListAllBugsCommand,
        ListAllStoriesCommand,
        ListAllFeedbacksCommand,
        ListAllTasksWithAssigneeCommand
    }
}
