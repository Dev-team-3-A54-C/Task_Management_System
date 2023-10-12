using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IHasActivityHistory
    {
        IList<IEvent> EventLog { get; }
        void AddEventToLog(string description);
    }
}
