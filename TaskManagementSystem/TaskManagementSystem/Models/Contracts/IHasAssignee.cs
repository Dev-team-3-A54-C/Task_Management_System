using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IHasAssignee
    {
        Member Assignee { get; }
        void AssignMember(Member member);
    }
}
