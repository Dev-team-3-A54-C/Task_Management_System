using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    internal interface IBug : ITask, IHasPriority, IHasAssignee
    {
        IList<string> StepsToReproduce { get; }
        Severity Severity { get; }
        BugStatus Status { get; }
    }
}
