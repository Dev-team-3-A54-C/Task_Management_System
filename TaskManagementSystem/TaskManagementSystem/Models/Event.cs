using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Event : IEvent
    {
        private string description;
        public Event(string description)
        {
            Description = description;
            Time = DateTime.Now;
        }

        public string Description
        {
            get => this.description;
            private set
            {
                if (value == null)
                    throw new InvalidUserInputException("Decription cannot be null");

                this.description = value;
            }
        }
        public DateTime Time { get; }

        public override string ToString()
        {
            return $"[{Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}] {Description}";
        }
    }
}
