using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Showing
{
    public class ShowPersonActivityCommand : BaseCommand
    {
        public ShowPersonActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {

        }

        //CommandParams should be:
        //[0] = string, personName
        public override string Execute()
        {
            string personName = CommandParameters[0];

            var person = this.Repository.GetMember(personName);

            StringBuilder output = new StringBuilder();

            foreach (var record in person.EventLog)
            {
                output.Append(record.ToString());
            }

            return output.ToString();
        }
    }
}
