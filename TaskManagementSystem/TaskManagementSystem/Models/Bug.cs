using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Bug : Task, IBug
    {
        
        public Bug(int id, string title, string description)
            : base(id, title, description)
        {
        }

        public IList<string> StepsToReproduce => throw new NotImplementedException();

        public Priority Priority => throw new NotImplementedException();

        public Member Assignee => throw new NotImplementedException();

        SeverityType IBug.Severity => throw new NotImplementedException();

        BugStatusType IBug.Status => throw new NotImplementedException();
    }
}
