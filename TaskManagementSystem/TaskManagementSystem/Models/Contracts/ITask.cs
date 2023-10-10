using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface ITask
    {
        int Id { get; }

        string Title { get;}

        string Description { get;}

        IList<Comment> Comments { get; }
        IList<EventLog> History { get; }
    }
}
