using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Team : HasName, ITeam
    {
       
        private const int NameMinValue = 5;
        private const int NameMaxValue = 15;
        private const string NameExceptionMessage = "Name of the team must be between {0} and {1} symbols";

        public Team(string name, IList<Member> members, IList<Board> boards)
            :base(NameMinValue, NameMaxValue, NameExceptionMessage)
        {
            Name = name;
        }

        // Todo
        // name must be unique method

        // Todo
        public IList<IMember> Member => throw new NotImplementedException();

        // Todo
        public IList<IBoard> Boards => throw new NotImplementedException();
    }
}
