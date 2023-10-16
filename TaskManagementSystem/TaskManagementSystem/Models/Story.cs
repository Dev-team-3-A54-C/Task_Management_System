using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Story : Task, IStory
    {
        public Story(int id, string title, string description, SizeType size, PriorityType priority)
            : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            Status = StoryStatusType.NotDone;
            TaskType = TaskType.Story;
            base.AddEventToLog($"Story with \"{Title}\" created");
        }

        public SizeType Size { get; private set; }

        public StoryStatusType Status { get; private set; }

        public PriorityType Priority { get; private set; }

        public Member Assignee { get; private set; }

        public override void AdvanceStatus()
        {
            if (Status != StoryStatusType.Done)
            {
                StoryStatusType oldStatus = Status;
                Status++;
                base.AddEventToLog($"The status of the story \"{Title}\" advanced from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot advance the status of the story \"{Title}\" more than \"{Status}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != StoryStatusType.NotDone)
            {
                StoryStatusType oldStatus = Status;
                Status--;
                base.AddEventToLog($"The status of the story \"{Title}\" reversed from \"{oldStatus}\" to \"{Status}\"");
            }
            else
            {
                string exceptionMessage = $"Cannot reverse the status of the story \"{Title}\" more than \"{Status}\"";

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
                base.AddEventToLog($"The priority of the story \"{Title}\" changed from \"{oldPriority}\" to \"{Priority}\"");
            }
            else
            {
                string exceptionMessage = $"The priority of the story \"{Title}\" is already \"{priority}\"";

                base.AddEventToLog(exceptionMessage);
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        public void SetSize(SizeType size)
        {
            SizeType oldSize = Size;
            Size = size;
            base.AddEventToLog($"The rating of the feedback \"{Title}\" changed from \"{oldSize}\" to \"{Size}\"");
        }

        public void AssignMember(Member member)
        {
            Assignee = member;
            base.AddEventToLog($"\"{member.Name}\" assigned to the the story \"{Title}\"");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"     Size: {Size}");
            stringBuilder.AppendLine($"     Priority: {Priority}");
            stringBuilder.AppendLine($"     Status: {Status}");
            stringBuilder.AppendLine($"     Assignee: {Assignee}");
            stringBuilder.AppendLine(ListComments());
            
            return stringBuilder.ToString();
        }
    }
}
