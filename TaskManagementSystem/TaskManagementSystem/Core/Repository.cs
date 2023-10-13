using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagementSystem.Core.Contracts;
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
            return team;
        }
        public IComment CreateComment(string content, string author)
        {
            IComment comment = new Comment(content, author);
            return comment;
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
            IBug bug = (IBug)tasks.FirstOrDefault(x => x.Title == title && x.GetType() == typeof(Bug));
            return bug;
        }

        public IStory GetStory(string title)
        {
            IStory story = (IStory)tasks.FirstOrDefault(x => x.Title == title && x.GetType() == typeof(Story));
            return story;
        }

        public IFeedback GetFeedback(string title)
        {
            IFeedback feedback = (IFeedback)tasks.FirstOrDefault(x => x.Title == title && x.GetType() == typeof(Feedback));
            return feedback;
        }
        public ITask GetTask(string name)
        {
            ITask task = tasks.FirstOrDefault(x => x.Title == name);
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
            return board;
        }

        
    }
}
