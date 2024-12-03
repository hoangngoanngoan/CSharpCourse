using System;

namespace Controller
{
    public class InvalidItemNameException : Exception
    {
        public string InvalidItemName { get; set; }

        public InvalidItemNameException() : base() { }

        public InvalidItemNameException(string message) : base(message) { }

        public InvalidItemNameException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidItemNameException(string message, string invalidItemName) : base(message)
        {
            InvalidItemName = invalidItemName;
        }
    }
}
