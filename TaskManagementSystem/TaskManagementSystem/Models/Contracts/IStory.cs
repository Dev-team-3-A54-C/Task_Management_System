using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IStory : ITask, IHasPriority, IHasAssignee
    {
        StorySize Size { get; }
        StoryStatus Status { get; }
    }
}
