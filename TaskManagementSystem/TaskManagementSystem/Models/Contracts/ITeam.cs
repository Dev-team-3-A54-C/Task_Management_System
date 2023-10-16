using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        void AddMember(IMember member);
        void AddBoard(IBoard board);
    }
}
