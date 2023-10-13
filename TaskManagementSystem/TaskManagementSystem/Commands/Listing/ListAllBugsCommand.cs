using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands.Listing
{
    public class ListAllBugsCommand : BaseCommand
    {
        public ListAllBugsCommand(IRepository repository) : base(repository)
        { 
        }
        public override string Execute()
        {
            StringBuilder sb = new StringBuilder();
            IList<ITask> bugs = this.Repository.Tasks.Where(x => x.GetType() == typeof(Bug)).ToList();
            foreach(var item in bugs)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
