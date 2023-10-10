﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Feedback : Task, IFeedback
    {

        public Feedback(int id, string title, string description)
            : base(id, title, description)
        {
        }

        public int Rating { get; private set; }

        // Todo
        public FeedbackStatus status => throw new NotImplementedException();
    }
}
