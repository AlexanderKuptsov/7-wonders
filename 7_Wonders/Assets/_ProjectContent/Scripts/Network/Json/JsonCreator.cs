using Newtonsoft.Json;

namespace Network.Json
{
    public class JsonCreator
    {
        public static string createJson(string type, string attributes)
        {
            var package = new JsonPack()
            {
                data = new JsonInfo()
                {
                    type = type,
                    attributes = attributes
                }
            };
            var jsonString = JsonConvert.SerializeObject(package);
            jsonString = jsonString.Replace("\\\"", "\""); //TODO ???
            return jsonString;
        }
    }

    public class JsonPack
    {
        public JsonInfo data { get; set; }
    }


    public class JsonInfo
    {
        public string type { get; set; }
        public string attributes { get; set; }
    }

    public class AdvancedJsonInfo
    {
        public string type { get; set; }
        public string attributes { get; set; }
        public string SESSIONID { get; set; }
    }

    public class AdvancedJsonPack
    {
        public AdvancedJsonInfo data { get; set; }
    }
}