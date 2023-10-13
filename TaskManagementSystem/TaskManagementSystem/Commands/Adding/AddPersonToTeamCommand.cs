﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands.Adding
{
    public class AddPersonToTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public AddPersonToTeamCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository) 
        {           
        }

        //CommandParams should be:
        //[0] = string, personName
        //[1] = string, teamName
        public override string Execute()
        {
            if (this.CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}.");
            }

            string personName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var person = this.Repository.GetMember(personName);
            if (person == null)
            {
                throw new InvalidMemberException($"Person with the name '{personName}' does not exist.");
            }

            var team = this.Repository.GetTeam(teamName);
            if (team == null)
            {
                throw new InvalidTeamException($"Team with the name '{teamName}' does not exist.");
            }

            team.AddMember(person);

            return $"Person '{personName}' is now a member of team '{teamName}'.";
        }
    }
}
