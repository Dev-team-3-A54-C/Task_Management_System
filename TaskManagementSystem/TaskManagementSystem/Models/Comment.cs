using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Comment : IComment
    {
        private string message;
        private const string MessageExceptionMessage = "Message cannot be null";

        private string author;
        private const int AuthorMinValue = 5;
        private const int AuthorMaxValue = 15;
        private const string AuthorExceptionMessage = "Author of the comment must be between {0} and {1} symbols";

        public Comment(string message, string author)
        {
            Message = message;
            Author = author;
        }
        public string Message
        {
            get => this.message;
            private set
            {
                ValidationHelpers.ValidationHelper.ValidateIfStringIsNull(value, MessageExceptionMessage);
                this.message = value;
            }
        }

        public string Author
        {
            get => this.author;
            private set
            {
                ValidationHelpers.ValidationHelper.ValidateStringLength(value, AuthorMinValue, AuthorMaxValue, AuthorExceptionMessage);
                this.author = value;
            }
        }
    }
}
