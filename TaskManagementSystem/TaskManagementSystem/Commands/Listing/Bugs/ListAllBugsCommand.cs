using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Bugs
{
    public class ListAllBugsCommand : BaseCommand
    {
        public ListAllBugsCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {       
            IList<IBug> bugs = Repository.SortBugs();

            StringBuilder sb = new StringBuilder();
            foreach (var item in bugs)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
