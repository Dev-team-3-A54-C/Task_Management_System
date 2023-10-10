using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.ValidationHelpers
{
    public static class ValidationHelper
    {
        public static void ValidateStringLength(string value, int minValue, int maxValue, string message)
        {
            if (value.Length < minValue || value.Length > maxValue)
                throw new InvalidUserInput(message);
        }
    }
}
