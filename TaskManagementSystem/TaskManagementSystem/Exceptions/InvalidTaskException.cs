using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions
{
    public class InvalidTaskException : ApplicationException
    {
        public InvalidTaskException(string message) : base(message)
        {
            
        }
    }
}
