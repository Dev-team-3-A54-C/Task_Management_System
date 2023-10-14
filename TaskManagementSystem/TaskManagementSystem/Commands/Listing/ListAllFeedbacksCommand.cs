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
    public class ListAllFeedbacksCommand : BaseCommand
    {
        public ListAllFeedbacksCommand(IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            //todo
            //Approach -
            //1. Create a collection of feedbacks only
            //2. Sort them by title, than by rating
            //3. Append them to the sb
            StringBuilder sb = new StringBuilder();
            IList<IFeedback> feedbacks = this.Repository.Tasks.Where(x => x.GetType() == typeof(Feedback))
                .Select(x => (IFeedback)x)
                .OrderBy(x => x.Title)
                .ThenBy(x => x.Rating)
                .ToList();
            foreach (var item in feedbacks)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
