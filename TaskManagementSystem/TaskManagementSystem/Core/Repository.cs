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

        public IList<ITeam> Teams
        {
            get
            {
                return new List<ITeam>(teams);
            }
        }
        public void AddTeam(Team t)
        {
            throw new NotImplementedException();
        }

        public IComment CreateComment(string content, string author)
        {
            throw new NotImplementedException();
        }

        public ITask CreateTask(string title, string description)
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

        public bool TeamExists(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
