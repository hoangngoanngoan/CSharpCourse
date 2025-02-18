using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Controller
{
    public class Provider
    {

        private static Provider instance;

        public static Provider Instance
        {
            get { if (instance == null) instance = new Provider(); return instance; }
            private set { instance = value; }
        }
        private Provider() { }

        public List<T> ReadFromFile<T>(string path)
        {
            string jsonString = File.ReadAllText(path); 
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        public void WriteToFile<T>(string filePath, List<T> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
