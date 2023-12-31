﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Commands.Contracts;

namespace TaskManagementSystem.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string input);
    }
}
