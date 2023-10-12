using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IHasTasks
    {
        IList<ITask> Tasks { get; }
        void AddTask(ITask task);
        void RemoveTask(ITask task);
    }
}
