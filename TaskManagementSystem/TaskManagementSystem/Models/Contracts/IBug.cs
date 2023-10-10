using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    internal interface IBug : ITask, IHasPriority
    {
        IList<string> Steps { get; }
        Severity Severity { get; }
        BugStatus Status { get; }
        Member Assignee { get; }
        IList<string> Comments { get; }
        IList<string> History { get; }
    }
}
