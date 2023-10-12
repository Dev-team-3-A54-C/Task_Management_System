using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public abstract class HasName
    {
        private string name;
        private readonly int minValue;
        private readonly int maxValue;
        private readonly string exceptionMessage;

        public HasName(string name, int MinValue, int MaxValue, string ExceptionMessage)
        {
            Name = name;
            this.minValue = MinValue;
            this.maxValue = MaxValue;
            this.exceptionMessage = $"{ExceptionMessage} of the member must be between {MinValue} and {MaxValue} symbols";
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                ValidationHelpers.ValidationHelper.ValidateStringLength(value, minValue, maxValue, exceptionMessage);
                this.name = value;
            }
        }
    }
}
