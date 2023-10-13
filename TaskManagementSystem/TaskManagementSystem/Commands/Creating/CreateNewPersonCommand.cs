using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Creating
{
    public class CreateNewPersonCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public CreateNewPersonCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        //CommandParams should be:
        //[0] = string, personName
        public override string Execute()
        {
            if(this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string personName = this.CommandParameters[0];

            this.Repository.CreatePerson(personName);

            return $"Person with the name {personName} was created!";
        }
    }
}
