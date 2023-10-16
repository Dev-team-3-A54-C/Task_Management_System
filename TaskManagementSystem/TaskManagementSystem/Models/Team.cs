using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Team : ITeam
    {
        private string name = "";
        private const int NameMinValue = 5;
        private const int NameMaxValue = 15;
        private const string NameExceptionMessage = "Name of the team must be between {0} and {1} symbols";

        private IList<IMember> members = new List<IMember>();
        private IList<IBoard> boards = new List<IBoard>();
        private IList<IEvent> eventLog = new List<IEvent>();

        public Team(string name)
        {
            Name = name;
            AddEventToLog($"Created team with name \"{Name}\"");
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                ValidationHelpers.ValidationHelper.ValidateStringLength(value, NameMinValue, NameMaxValue, NameExceptionMessage);
                this.name = value;
            }
        }

        public IList<IMember> Members
        {
            get => new List<IMember>(members);
        }

        public IList<IBoard> Boards
        {
            get => new List<IBoard>(boards);
        }

        public IList<IEvent> EventLog
        {
            get => new List<IEvent>(eventLog);
        }

        public void AddMember(IMember member)
        {
            if (members.Contains(member))
                throw new DuplicateItemException($"Member with name \"{member.Name}\" already exist in the team \"{Name}\"");

            members.Add(member);
            AddEventToLog($"Added \"{member.Name}\" to team \"{Name}\"");
        }

        public void AddBoard(IBoard board)
        {
            if (boards.Contains(board))
                throw new DuplicateItemException($"Board with name \"{board.Name}\" already exist in the team \"{Name}\"");

            boards.Add(board);
            AddEventToLog($"Added \"{board.Name}\" to team \"{Name}\"");
        }

        public void AddEventToLog(string description)
        {
            eventLog.Add(new Event(description));
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
