using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public abstract class HasName : IHasName
    {
        private string name = "";
        private readonly int minValue;
        private readonly int maxValue;
        private readonly string exceptionMessage;

        public HasName(string name, int MinValue, int MaxValue, string ExceptionMessage)
        {
            this.minValue = MinValue;
            this.maxValue = MaxValue;
            Name = name;
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
