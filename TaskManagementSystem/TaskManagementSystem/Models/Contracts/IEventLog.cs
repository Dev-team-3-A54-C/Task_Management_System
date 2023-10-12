using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Enums
{
    public interface IEvent
    {
        string Description { get; }
        DateTime Time { get; }
    }
}
