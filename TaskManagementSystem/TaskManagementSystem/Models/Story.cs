using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Story : Task, IStory
    {
        public Story(int id, string title, string description, )
            : base(id, title, description)
        {
        }

        public StorySize Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public Priority Priority => throw new NotImplementedException();

        public Member Assignee => throw new NotImplementedException();
    }
}
