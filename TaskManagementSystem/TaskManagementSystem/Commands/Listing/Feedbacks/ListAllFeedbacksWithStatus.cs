using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands.Listing.Feedbacks
{
    public class ListAllFeedbacksWithStatus : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ListAllFeedbacksWithStatus(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}.");
            }

            FeedbackStatusType status = base.ParseFeedbackStatusParameter(CommandParameters[0], "FeedbackStatus");

            IList<IFeedback> feedbacks = Repository.FilterFeedbacksByStatus(status);

            StringBuilder sb = new StringBuilder();
            foreach (var item in feedbacks)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
