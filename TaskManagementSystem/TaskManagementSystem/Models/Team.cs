using Microsoft.VisualBasic;
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

        public IList<IMember> Members
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"--- Team: {Name} ---");
            stringBuilder.AppendLine($"     Members:");

            foreach (IMember member in members)
            {
                stringBuilder.AppendLine($"      {member.Name}");
            }

            stringBuilder.AppendLine($"     Boards:");

            foreach (IBoard board in boards)
            {
                stringBuilder.AppendLine($"      {board.Name}");
            }

            return stringBuilder.ToString();
        }
    }
}
