using Echo.Models;
using Newtonsoft.Json;
namespace Echo.Helpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, Exhibit> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName); 
            return JsonConvert.DeserializeObject<Dictionary<int, Exhibit>>(jsonString);
        }
        public static Dictionary<int, Article> ReadJsonArticle(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Article>>(jsonString); 
        }
    }
}
