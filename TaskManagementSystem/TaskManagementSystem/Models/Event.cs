using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public class Event : IEvent
    {
        public Event(string description)
        {
            Description = description;
            Time = DateTime.Now;
        }

        public string Description { get; }
        public DateTime Time { get; }

        public override string ToString()
        {
            return $"[{Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}] {Description}";
        }
    }
}
