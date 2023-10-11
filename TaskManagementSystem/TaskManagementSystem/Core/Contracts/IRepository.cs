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

        bool TeamExists(string teamName);


        ITeam CreateTeam(string name);
        IComment CreateComment(string content, string author);
        ITask CreateTask(string title, string description);
        IMember CreatePerson(string name);
        IBoard CreateBoard(string name); //?

        ITeam GetTeam(string teamName);
        IMember GetMember(string name);
        IBoard GetBoard(string name);

        ITask GetTask(string name);

        
        
        void ChangeBugPriority(IBug bug);
        void ChangeBugSeverity(IBug bug);
        void ChangeBugStatus(IBug bug);
        void ChangeStoryPriority(IStory story);
        void ChangeStoryStatus(IStory story);

        void ChangeStorySize(IStory story);
        void ChangeRating(IFeedback feedback);
        void ChangeStatus(IFeedback feedback);
    }
}
