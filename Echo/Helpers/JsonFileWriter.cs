using Echo.Models;
using Newtonsoft.Json;

namespace Echo.Helpers
{
    public class JsonFileWriter
    {
       public static void WriteToJson(Dictionary<int, Exhibit> exhibits, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(exhibits, Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteArticleToJson(Dictionary<int, Article> articles, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(articles, Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
