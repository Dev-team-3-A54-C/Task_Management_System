using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IFeedback : ITask
    {
        int Rating { get;}
        FeedbackStatus status { get;}
    }
}
