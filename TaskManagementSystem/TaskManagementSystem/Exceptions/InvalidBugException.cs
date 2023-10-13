using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions
{
    public class InvalidBugException : ApplicationException
    {
        public InvalidBugException(string message) : base(message)
        {
            
        }
    }
}
