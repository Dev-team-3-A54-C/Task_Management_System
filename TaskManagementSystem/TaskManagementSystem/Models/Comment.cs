using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Comment : IComment
    {
        public string Message => throw new NotImplementedException();

        public string Author => throw new NotImplementedException();
    }
}
