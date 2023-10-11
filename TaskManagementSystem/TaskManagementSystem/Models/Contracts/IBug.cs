using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBug : ITask, IHasPriority, IHasAssignee
    {
        IList<string> StepsToReproduce { get; }
        SeverityType Severity { get; }
        BugStatusType Status { get; }
        void IncreaseSeverity();
        void LowerSeverity();
    }
}
