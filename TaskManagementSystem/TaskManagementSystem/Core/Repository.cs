using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

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
        public void AddTeam(Team t)
        {
            throw new NotImplementedException();
        }

        public void ChangeRating(IFeedback feedback)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(IFeedback feedback)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryPriority(IStory story)
        {
            throw new NotImplementedException();
        }

        public void ChangeStorySize(IStory story)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryStatus(IStory story)
        {
            throw new NotImplementedException();
        }

        public IBoard CreateBoard(string name)
        {
            throw new NotImplementedException();
        }

        public IComment CreateComment(string content, string author)
        {
            throw new NotImplementedException();
        }

        public IMember CreateNewPerson(string name)
        {
            throw new NotImplementedException();
        }

        public IMember CreatePerson(string name)
        {
            throw new NotImplementedException();
        }

        public ITask CreateTask(string title, string description)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public IBoard GetBoard(string name)
        {
            throw new NotImplementedException();
        }

        public IMember GetMember(string name)
        {
            throw new NotImplementedException();
        }

        public ITask GetTask(string name)
        {
            throw new NotImplementedException();
        }

        public ITeam GetTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public void RemoveTeam(Team t)
        {
            throw new NotImplementedException();
        }

        public string ShowAllTeams()
        {
            throw new NotImplementedException();
        }

        public bool TeamExists(string teamName)
        {
            throw new NotImplementedException();
        }

        void IRepository.ChangeBugPriority(IBug bug)
        {
            throw new NotImplementedException();
        }

        void IRepository.ChangeBugSeverity(IBug bug)
        {
            throw new NotImplementedException();
        }

        void IRepository.ChangeBugStatus(IBug bug)
        {
            throw new NotImplementedException();
        }
    }
}
