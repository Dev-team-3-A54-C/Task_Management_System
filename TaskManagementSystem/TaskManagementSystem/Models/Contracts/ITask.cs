using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{
    public interface ITask
    {
        int Id { get; }

        string Title { get;}

        string Description { get;}

        IList<IComment> Comments { get; }
        IList<IEvent> EventLog { get; }
        void AdvanceStatus();
        void ReverseStatus();
        void AddComment(IComment comment);
        string ToString();
    }
}
