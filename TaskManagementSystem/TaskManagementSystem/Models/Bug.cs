using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Bug : Task, IBug
    {
        private IList<string> reproductionSteps = new List<string>();

        public Bug(int id, string title, string description, IList<string> stepsToReproduce, PriorityType priority, SeverityType severity)
            : base(id, title, description)
        {
            StepsToReproduce = stepsToReproduce;
            Priority = priority;
            Severity = severity;
            Status = BugStatusType.Active;
            TaskType = TaskType.Bug;
            base.AddEventToLog($"Bug with \"{Title}\" created");
        }

        public IList<string> StepsToReproduce
        {
            get => new List<string>(reproductionSteps);
            private set
            {
                this.reproductionSteps = value;
            }
        }

        public PriorityType Priority { get; private set; }

        public Member Assignee { get; private set; }

        public SeverityType Severity { get; private set; }

        public BugStatusType Status { get; private set; }

        public override void AdvanceStatus()
        {
            if (Status != BugStatusType.Fixed)
            {
                BugStatusType oldStatus = Status;
                Status = BugStatusType.Fixed;
                base.AddEventToLog($"The status of the bug \"{Title}\" advanced from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot advance the status of the bug \"{Title}\" more than \"{Status}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != BugStatusType.Active)
            {
                BugStatusType oldStatus = Status;
                Status = BugStatusType.Active;
                base.AddEventToLog($"The status of the bug \"{Title}\" reversed from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot reverse the status of the bug \"{Title}\" more than \"{Status}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public void SetPriority(PriorityType priority)
        {
            if (Priority != priority)
            {
                PriorityType oldPriority = Priority;
                Priority = priority;
                base.AddEventToLog($"The priority of the bug \"{Title}\" changed from \"{oldPriority}\" to \"{Priority}\"");
            }
            else
            {
                string exceptionMessage = $"The priority of the bug \"{Title}\" is already \"{priority}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public void SetSeverity(SeverityType severity)
        {
            if (Severity != severity)
            {
                SeverityType oldSeverity = Severity;
                Severity = severity;
                base.AddEventToLog($"The severity of the bug \"{Title}\" changed from \"{oldSeverity}\" to \"{Severity}\"");
            }
            else
            {
                string exceptionMessage = $"The severity of the bug \"{Title}\" is already \"{severity}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public void AssignMember(Member member)
        {
            Assignee = member;
            base.AddEventToLog($"\"{member.Name}\" assigned to the bug \"{Title}\"");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"     Steps to Reproduce:");

            int count = 1;
            foreach(string step in StepsToReproduce)
            {
                stringBuilder.AppendLine($"         {count++}. {step}");
            }

            stringBuilder.AppendLine($"     Priority: {Priority}");
            stringBuilder.AppendLine($"     Severity: {Severity}");
            stringBuilder.AppendLine($"     Status: {Status}");
            stringBuilder.AppendLine(ListComments());

            return stringBuilder.ToString();
        }
    }
}
