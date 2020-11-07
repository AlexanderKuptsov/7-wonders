using Newtonsoft.Json;

namespace Network.Json
{

    public enum AuthType
    {
        register,
        auth
    }
    public class JsonCreator
    {
        public static string CreateJson(string type, string attributes)
        {
            var package = new Root()
            {
                data = new Data()
                {
                    type = type,
                    attributes = attributes
                }
            };
            var jsonString = JsonConvert.SerializeObject(package);
            jsonString = jsonString.Replace("\\\"", "\""); //TODO ???
            return jsonString;
        }

        public static string CreateAuthJson(AuthType authType, string username, string password)
        {
            var authAttributes = new AuthAttributes()
            {
                username = username,
                password = password
            };
            var jsonString = JsonConvert.SerializeObject(authAttributes);
            return RemoveSlash(CreateJson(authType.ToString(), jsonString));
        }
        
        public static string RemoveSlash(string pack)
        {
            pack = pack.Replace("\"{", "{"); //TODO ???
            pack = pack.Replace("}\"", "}"); //TODO ???
            return pack;
        }
    }

    public class AuthAttributes    {
        public string username { get; set; } 
        public string password { get; set; } 
    }

    public class Data    {
        public string type { get; set; } 
        public string attributes { get; set; } 
    }

    public class Root    {
        public Data data { get; set; } 
    }
}