﻿using System;
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
        ITask GetTask(string name);

        IMember CreateMember(string name);
        IMember GetMember(string name);

        IBoard CreateBoard(string name);
        IBoard GetBoard(string name);



    }
}
