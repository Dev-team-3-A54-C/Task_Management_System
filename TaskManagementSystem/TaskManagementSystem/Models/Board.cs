using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Board : HasName, IBoard
    {
        private string name;

        private const int NameMinValue = 5;
        private const int NameMaxValue = 10;
        private const string NameExceptionMessage = "Name of the board must be between {0} and {1} symbols";

        public Board(string name, IList<Member> members, IList<Board> boards)
            : base(NameMinValue, NameMaxValue, NameExceptionMessage)
        {
            Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidationHelpers.ValidationHelper.ValidateStringLength(value, NameMinValue, NameMaxValue, NameExceptionMessage);
                this.name = value;
            }
        }
        // Todo
        public IList<Task> Tasks => throw new NotImplementedException();
    }
}
