using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IStory : IHasPriority, IHasAssignee
    {
        SizeType Size { get; }
        StoryStatusType Status { get; }
        void SetSize(SizeType size);
    }
}
