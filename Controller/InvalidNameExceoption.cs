using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class InvalidNameExceoption : Exception
    {
        public string InvalidName { get; set; }
        public InvalidNameExceoption() { }
        public InvalidNameExceoption(string message) : base(message) { }
        public InvalidNameExceoption(string message, Exception innerException) : base(message, innerException) { }
        public InvalidNameExceoption(string message, string invalidName) : base(message)
        {
            InvalidName = invalidName;
        }
    }
}
