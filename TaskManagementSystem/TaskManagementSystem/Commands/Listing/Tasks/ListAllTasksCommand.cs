using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;


namespace TaskManagementSystem.Commands.Listing.Tasks
{
    public class ListAllTasksCommand : BaseCommand
    {
        public ListAllTasksCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            IList<ITask> tasks = Repository.Tasks
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in tasks)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
