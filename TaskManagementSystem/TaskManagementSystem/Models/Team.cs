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

        private IList<IMember> members = new List<IMember>();
        private IList<IBoard> boards = new List<IBoard>();

        public Team(string name)
            :base(name, NameMinValue, NameMaxValue, NameExceptionMessage)
        {
        }

        public IList<IMember> Member
        {
            get => new List<IMember>(members);
        }

        public IList<IBoard> Boards
        {
            get => new List<IBoard>(boards);
        }
        public void AddMember(IMember member)
        {
            members.Add(member);
        }

        public void AddBoard(IBoard board)
        {
            boards.Add(board);
        }

        public override string ToString()
        {
            return "todo";
            // Todo
        }
    }
}
