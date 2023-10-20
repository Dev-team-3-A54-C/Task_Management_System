using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        CreateNewPerson,
        ShowAllPeople,
        ShowPersonActivity,
        CreateNewTeam,
        ShowAllTeams,
        ShowTeamActivity,
        AddPersonToTeam,
        ShowAllTeamMembers,
        CreateNewBoardInTeam,
        ShowAllTeamBoards,
        ShowBoardActivity,
        CreateNewBugInBoard,
        CreateNewStoryInBoard,
        CreateNewFeedbackInBoard,
        ChangePriorityOfBug,
        ChangeSeverityOfBug,
        ChangeStatusOfBug,
        ChangePriorityOfStory,
        ChangeStatusOfStory,
        ChangeSizeOfStory,
        ChangeRatingOfFeedback,
        ChangeStatusOfFeedback,
        AssignPersonToTask,
        UnassignPersonFromTask,
        AddCommentToTask,
        ListAllTasks,
        ListAllTasksWithAssignee,
        ListAllTasksWithTitle,
        ListAllBugs,
        ListAllBugsWithAssignee,
        ListAllBugsWithStatus,
        ListAllStories,
        ListAllStoriesWithAssignee,
        ListAllStoriesWithStatus,
        ListAllFeedbacks,
        ListAllFeedbacksWithStatus,
        Help
    }
}
