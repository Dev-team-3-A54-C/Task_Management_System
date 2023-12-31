﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.ValidationHelpers
{
    public static class ValidationHelper
    {
        public static void ValidateStringLength(string value, int minValue, int maxValue, string message)
        {
            if (value.Length < minValue || value.Length > maxValue)
                throw new InvalidUserInputException(string.Format(message, minValue, maxValue));
        }

        public static void ValidateIfIntIsNegative(int value, string message)
        {
            if (value <= 0)
                throw new InvalidUserInputException(message);
        }

        public static void ValidateIfStringIsNull(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(message);
        }
    }
}
