using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }

        public abstract string Execute();

        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        protected double ParseDoubleParameter(string value, string parameterName)
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be a real number.");
        }

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either true or false.");
        }

        protected BugStatusType ParseBugStatusParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out BugStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'Active' or 'Fixed'.");
        }

        protected FeedbackStatusType ParseFeedbackStatusParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out FeedbackStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'New', 'Unscheduled', 'Scheduled', 'Done'.");
        }

        protected PriorityType ParsePriorityParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out PriorityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'Low', 'Medium', 'High'.");
        }

        protected SeverityType ParseSeverityParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out SeverityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'Minor', 'Major', 'Critical'.");
        }

        protected SizeType ParseSizeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out SizeType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'Small', 'Medium', 'Large'.");
        }

        protected StoryStatusType ParseStoryStatusParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, out StoryStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either 'NotDone', 'InProgress', 'Done'.");
        }
    }
}
