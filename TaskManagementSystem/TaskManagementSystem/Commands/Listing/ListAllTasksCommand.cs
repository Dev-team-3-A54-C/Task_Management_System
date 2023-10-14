using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Commands.Listing
{
    public class ListAllTasksCommand : BaseCommand
    {
        public ListAllTasksCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            //todo
            StringBuilder sb = new StringBuilder();
            IList<ITask> tasks = this.Repository.Tasks.Where(x => x.GetType() == typeof(Task))
                .Select(x => (ITask)x)
                .OrderBy(x => x.Title)
                .ToList();
            foreach (var item in tasks)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
