using Model;
using System.Text.Json;

namespace DataAccess
{
    public class JsonDataset
    {
        public static List<Person> LoadData(string aPath)
        {
            var fileContent = File.ReadAllText(aPath);
            var people = JsonSerializer
                         .Deserialize<List<Person>>(fileContent);

            return people;
        }
    }
}
