using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IList<ITeam> Teams { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        IList<ITask> Tasks { get; }

        ITeam CreateTeam(string name);
        ITeam GetTeam(string teamName);

        IComment CreateComment(string content, string author);

        IBug CreateBug(string title, string description, PriorityType priority, SeverityType severity, IList<string> stepsToRep);
        IStory CreateStory(string title, string description, SizeType size, PriorityType priority);
        IFeedback CreateFeedback(string title, string description, int rating);
        IBug GetBug(string title);
        IStory GetStory(string title);
        IFeedback GetFeedback(string title);
        ITask GetTask(string title);

        IMember CreateMember(string name);
        IMember GetMember(string name);

        IBoard CreateBoard(string name);
        IBoard GetBoard(string name);

        //new methods
        IBug UpdateBugPriority(IBug bug, PriorityType p);
        IStory UpdateStoryPriority(IStory story, PriorityType p);
        IFeedback UpdateFeedbackRating(IFeedback feedback, int rating);
        IBug UpdateBugSeverity(IBug bug, SeverityType p);
        IStory UpdateStorySize(IStory story, SizeType size);
        IBug UpdateBugStatus(IBug bug, BugStatusType status);
        IFeedback UpdateFeedbackStatus(IFeedback feedback, FeedbackStatusType status);
        IStory UpdateStoryStatus(IStory story, StoryStatusType status);
        void AddMemberToTeam(IMember member, ITeam team);
        void AddCommentToTask(IComment comment, ITask task);

        //FILTERS

        //bugs
        IList<IBug> SortBugs();
        IList<IBug> FilterBugsByStatus(BugStatusType status);
        IList<IBug> FilterBugsByAssignee(IMember assignee);

        //stories
        IList<IStory> SortStories();
        IList<IStory> FilterStoriesByStatus(StoryStatusType status);
        IList<IStory> FilterStoriesByAssignee(IMember assignee);

        //feedbacks
        IList<IFeedback> SortFeedbacks();
        IList<IFeedback> FilterFeedbacksByStatus(FeedbackStatusType status);
        
        //tasks in general
        IList<ITask> FilterTasksByTitle(string title);
        IList<ITask> FilterTasksByAssignee(IMember assignee);


    }
}
