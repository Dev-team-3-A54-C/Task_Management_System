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
    public class ListAllStoriesCommand : BaseCommand
    {
        public ListAllStoriesCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            //todo
            //Approach -
            //1. Create a collection of stories only
            //2. Sort them by title, than by priority, than by size
            //3. Append them to the sb
            StringBuilder sb = new StringBuilder();
            IList<IStory> stories = this.Repository.Tasks.Where(x => x.GetType() == typeof(Story))
                .Select(x => (IStory)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Priority)
                .ThenBy(x => x.Size)
                .ToList();
            foreach (var item in stories)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
