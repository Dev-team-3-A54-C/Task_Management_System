using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        private readonly IList<ITask> tasks = new List<ITask>();

        public IList<ITeam> Teams
        {
            get
            {
                return new List<ITeam>(teams);
            }
        }
        public IList<IMember> Members
        {
            get
            {
                return new List<IMember>(members);
            }
        }
        public IList<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(boards);
            }
        }
        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(tasks);
            }
        }
        public ITeam CreateTeam(string name)
        {
            ITeam team = new Team(name);
            teams.Add(team);
            return team;
        }
        public ITeam GetTeam(string teamName)
        {
            ITeam team = teams.FirstOrDefault(x => x.Name == teamName);
            if (team == null)
            {
                throw new InvalidTeamException($"Team with the name '{teamName}' does not exist.");
            }
            return team;
        }
        public bool TeamExists(string teamName)
        {
            return teams.Any(x => x.Name == teamName);
        }
        public IComment CreateComment(string content, string author)
        {
            return new Comment(content, author);
        }
        public IBug CreateBug(string title, string description, PriorityType priority, SeverityType severity, IList<string> stepsToRep)
        {
            int nextId = tasks.Count;
            IBug bug = new Bug(++nextId, title, description, stepsToRep, priority, severity);
            tasks.Add(bug);
            return bug;
        }
        public IStory CreateStory(string title, string description, SizeType size, PriorityType priority)
        {
            int nextId = tasks.Count;
            IStory story = new Story(++nextId, title, description, size, priority);
            tasks.Add(story);
            return story;
        }
        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            int nextId = tasks.Count;
            IFeedback feedback = new Feedback(++nextId, title, description, rating);
            tasks.Add(feedback);
            return feedback;
        }
        public IBug GetBug(string title)
        { 
            IBug bug = (IBug)this.Tasks.FirstOrDefault(x => x.Title == title && x.TaskType == TaskType.Bug);
            if(bug == null)
            {
                throw new InvalidBugException($"Bug with title '{title}' does not exist.");
            }
            return bug;
        }

        public IStory GetStory(string title)
        {
            IStory story = (IStory)tasks.FirstOrDefault(x => x.Title == title && x.TaskType == TaskType.Story);
            if(story == null)
            {
                throw new InvalidStoryException($"Story with title '{title}' does not exist.");
            }
            return story;
        }

        public IFeedback GetFeedback(string title)
        {
            IFeedback feedback = (IFeedback)tasks.FirstOrDefault(x => x.Title == title && x.TaskType == TaskType.Feedback);
            if(feedback == null)
            {
                throw new InvalidFeedbackException($"Feedback with title '{title}' does not exist.");
            }
            return feedback;
        }
        public ITask GetTask(string title)
        {
            ITask task = tasks.FirstOrDefault(x => x.Title == title);
            if(task  == null)
            {
                throw new InvalidTaskException($"Task with the title '{title}' does not exist.");
            }
            return task;
        }
        public IMember CreateMember(string name)
        {
            IMember member = new Member(name);
            members.Add(member);
            return member;
        }
        public IMember GetMember(string name)
        {
            IMember member = members.FirstOrDefault(x => x.Name == name);
            if(member == null)
            {
                throw new InvalidMemberException($"Person with the name '{name}' does not exist.");
            }
            return member;
        }
        public IBoard CreateBoard(string name)
        {
            IBoard board = new Board(name);
            this.boards.Add(board);
            return board;
        }

        public IBoard GetBoard(string name)
        {
            IBoard board = boards.FirstOrDefault(x => x.Name == name);
            if(board == null)
            {
                throw new InvalidBoardException($"Board with name '{name}' does not exist");
            }
            return board;
        }

        //new methods for updating/adding
        public IBug UpdateBugPriority(IBug bug, PriorityType p)
        {
            bug.SetPriority(p);
            return bug;
        }
        public IStory UpdateStoryPriority(IStory story, PriorityType p)
        {
            story.SetPriority(p);
            return story;
        }

        public IFeedback UpdateFeedbackRating(IFeedback feedback, int rating)
        {
            feedback.SetRating(rating);
            return feedback;
        }
        public IBug UpdateBugSeverity(IBug bug, SeverityType s)
        {
            bug.SetSeverity(s);
            return bug;
        }
        public IStory UpdateStorySize(IStory story, SizeType size)
        {
            story.SetSize(size);
            return story;
        }
        public IBug UpdateBugStatus(IBug bug, BugStatusType status)
        {
            int statusDiff = (int)bug.Status - (int)status;

            if (statusDiff > 0)
            {
                while (statusDiff != 0)
                {
                    bug.ReverseStatus();
                    statusDiff--;
                }
            }
            else if (statusDiff < 0)
            {
                while (statusDiff != 0)
                {
                    bug.AdvanceStatus();
                    statusDiff++;
                }
            }
            return bug;
        }
        public IFeedback UpdateFeedbackStatus(IFeedback feedback, FeedbackStatusType status)
        {
            int statusDiff = (int)feedback.Status - (int)status;

            if (statusDiff > 0)
            {
                while (statusDiff != 0)
                {
                    feedback.ReverseStatus();
                    statusDiff--;
                }
            }
            else if (statusDiff < 0)
            {
                while (statusDiff != 0)
                {
                    feedback.AdvanceStatus();
                    statusDiff++;
                }
            }
            return feedback;
        }
        public IStory UpdateStoryStatus(IStory story, StoryStatusType status)
        {
            int statusDiff = (int)story.Status - (int)status;

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
            return story;
        }
        public void AddMemberToTeam(IMember member, ITeam team)
        {
            team.AddMember(member);
        }
        public void AddCommentToTask(IComment comment, ITask task)
        {
            task.AddComment(comment);
        }

        //FILTER METHODS

        //For bugs
        public IList<IBug> SortBugs()
        {
            return tasks.Where(x => x.TaskType == TaskType.Bug)
                .Select(x => (IBug)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Priority)
                .ThenBy(x => x.Severity)
                .ToList();
        }
        public IList<IBug> FilterBugsByStatus(BugStatusType status)
        {
            return SortBugs().Where(x => x.Status == status).ToList();
            //return tasks.Where(x => x.TaskType == TaskType.Bug)
            //    .Select(x => (IBug)x)
            //    .Where(x => x.Status == status)
            //    .OrderBy(x => x.Title)
            //    .ThenBy(x => x.Priority)
            //    .ThenBy(x => x.Severity)
            //    .ToList();
        }
        public IList<IBug> FilterBugsByAssignee(IMember assignee)
        {
            return SortBugs().Where(x => x.Assignee == assignee).ToList();
        }

        //For stories
        public IList<IStory> SortStories()
        {
            return tasks.Where(x => x.TaskType == TaskType.Story)
                .Select(x => (IStory)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Priority)
                .ThenBy(x => x.Size)
                .ToList();
        }
        public IList<IStory> FilterStoriesByStatus(StoryStatusType status)
        {
            //return tasks.Where(x => x.TaskType == TaskType.Story)
            //    .Select(x => (IStory)x)
            //    .Where(x => x.Status == status)
            //    .OrderBy(x => x.Title)
            //    .ThenBy(x => x.Priority)
            //    .ThenBy(x => x.Size)
            //    .ToList();
            return SortStories().Where(x => x.Status == status).ToList();
        }
        public IList<IStory> FilterStoriesByAssignee(IMember assignee)
        {
            //return tasks.Where(x => x.TaskType == TaskType.Story)
            //    .OrderBy(x => x.Title)
            //    .Select(x => (IStory)x)
            //    .Where(x => x.Assignee == assignee)
            //    .OrderBy(x => x.Priority)
            //    .ThenBy(x => x.Size)
            //    .ToList();
            return SortStories().Where(x => x.Assignee == assignee).ToList();
        }

        //For feedbacks
        public IList<IFeedback> SortFeedbacks()
        {
            return tasks.Where(x => x.TaskType == TaskType.Feedback)
                .Select(x => (IFeedback)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Rating)
                .ToList();
        }
        public IList<IFeedback> FilterFeedbacksByStatus(FeedbackStatusType status)
        {
            //return tasks.Where(x => x.TaskType == TaskType.Feedback)
            //    .Select(x => (IFeedback)x)
            //    .Where(x => x.Status == status)
            //    .OrderBy(x => x.Title)
            //    .ThenBy(x => x.Rating)
            //    .ToList();
            return SortFeedbacks().Where(x => x.Status == status).ToList();
        }

        //For tasks in general
        public IList<ITask> FilterTasksByTitle(string title)
        {
            return tasks.Where(x => x.Title == title)
                .OrderBy(x => x.Title)
                .ToList();
        }
        public IList<ITask> FilterTasksByAssignee(IMember assignee)
        {
            return tasks.Where(x => (x.TaskType == TaskType.Bug || x.TaskType == TaskType.Story))
                .OrderBy(x => x.Title)
                .Select(x => (IHasAssignee)x)
                .Where(x => x.Assignee == assignee)
                .Select(x => (ITask)x)
                .ToList();
        }
    }
}
