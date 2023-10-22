using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowAllPeopleCommand : BaseCommand
    {
        public ShowAllPeopleCommand(IRepository repository) : base(repository)
        {
            
        }

        //CommandParams should be none
        
        public override string Execute()
        {
            if(this.Repository.Members.Count == 0)
            {
                return "There are no people added.";
            }

            StringBuilder output = new StringBuilder();

            foreach(var person in this.Repository.Members)
            {
                output.AppendLine(person.ToString());
            }

            return output.ToString();
        }
    }
}
