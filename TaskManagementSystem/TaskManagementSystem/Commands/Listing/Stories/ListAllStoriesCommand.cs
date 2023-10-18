using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Stories
{
    public class ListAllStoriesCommand : BaseCommand
    {
        public ListAllStoriesCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            //IList<IStory> stories = Repository.Tasks.Where(x => x.TaskType == TaskType.Story)
            //    .Select(x => (IStory)x)
            //    .OrderBy(x => x.Title)
            //    .ThenBy(x => x.Priority)
            //    .ThenBy(x => x.Size)
            //    .ToList();
            IList<IStory> stories = Repository.SortStories();

            StringBuilder sb = new StringBuilder();
            foreach (var item in stories)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
