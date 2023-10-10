using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Member : HasName, IMember
    {
        private string name;
        private const int NameMinValue = 5;
        private const int NameMaxValue = 15;
        private const string NameExceptionMessage = "Name";

        public Member(string name)
            : base(NameMinValue, NameMaxValue, NameExceptionMessage)
        {
            Name = name;
        }
        // Todo
        public IList<Task> Tasks => throw new NotImplementedException();
    }
}
