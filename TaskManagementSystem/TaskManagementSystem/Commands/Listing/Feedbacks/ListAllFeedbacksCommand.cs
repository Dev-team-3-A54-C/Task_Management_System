using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Feedbacks
{
    public class ListAllFeedbacksCommand : BaseCommand
    {
        public ListAllFeedbacksCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            
            //IList<IFeedback> feedbacks = Repository.Tasks.Where(x => x.TaskType == TaskType.Feedback)
            //    .Select(x => (IFeedback)x)
            //    .OrderBy(x => x.Title)
            //    .ThenBy(x => x.Rating)
            //    .ToList();

            IList<IFeedback> feedbacks = Repository.SortFeedbacks();

            StringBuilder sb = new StringBuilder();
            foreach (var item in feedbacks)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
