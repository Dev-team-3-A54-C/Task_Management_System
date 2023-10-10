using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Comment : IComment
    {
        public Comment(string message, string author)
        {
            Message = message;
            Author = author;
        }
        public string Message { get; private set;}

        public string Author { get; private set; }
    }
}
