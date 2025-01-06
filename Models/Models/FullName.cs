using Newtonsoft.Json;

namespace Models
{
    public class FullName
    {
        [JsonProperty("first")]
        public string FirstName { get; set; }

        [JsonProperty("mid")]
        public string MidName { get; set; }
        
        [JsonProperty("last")]
        public string LastName { get; set; }

        public FullName() { }

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
