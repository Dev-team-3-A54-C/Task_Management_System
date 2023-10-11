using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        void AddTeam(Team t);

        void RemoveTeam(Team t);

        bool TeamExists(string teamName);

        ITeam GetTeam(string teamName);

        IComment CreateComment(string content, string author);

        ITask CreateTask(string title, string description);
    }
}
