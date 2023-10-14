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
            //todo
            //Approach -
            //1. Create a collection of bugs only
            //2. Sort them by title, than by priority, than by severity
            //3. Append them to the sb
            StringBuilder sb = new StringBuilder();
            IList<IBug> bugs = this.Repository.Tasks.Where(x => x.GetType() == typeof(Bug))
                .Select(x => (IBug)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Priority)
                .ThenBy(x => x.Severity)
                .ToList();
                
            foreach(var item in bugs)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
