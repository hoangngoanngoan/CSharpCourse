using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }

        public FullName()
        {

        }

        public FullName(string fullName)
        {
            var data = fullName?.Split(' ');
            LastName = data[0];
            FirstName = data[data.Length - 1];
            string mid = "";
            for (int i = 1; i < data.Length - 1; i++)
            {
                mid += data[i] + " ";
            }
            MidName = mid.TrimEnd();
        }
        public FullName(string firstName, string midName, string lastName)
        {
            FirstName = firstName;
            MidName = midName;
            LastName = lastName;
        }

        public override string ToString() 
        {
            return $"{LastName} {MidName} {FirstName}";
        }
    }
}
