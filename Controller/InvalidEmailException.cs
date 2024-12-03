using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class InvalidEmailException : Exception
    {
        public string InvalidName { get; set; }
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception InnerException):base(message, InnerException) { }
        public InvalidEmailException(string message, string invalidName): base(message)
        {
            InvalidName = invalidName;
        }

    }
}
