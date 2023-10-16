using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBoard : IHasName, IHasTasks, IHasActivityHistory
    {
        string ToString();
    }
}
