using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions
{
    public class DuplicateItemException : ApplicationException
    {
        public DuplicateItemException(string message)
            : base(message)
        {

        }
    }
}
