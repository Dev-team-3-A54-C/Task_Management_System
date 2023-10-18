using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IHasAssignee
    {
        IMember Assignee { get; }
        void AssignMember(IMember member);
        void UnassignMember();
    }
}
