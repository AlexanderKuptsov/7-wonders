using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;

public static class AuthJsonCreator
{
    public enum AuthType
    {
        register,
        auth
    }
    
    private static string CreateAuthJson(AuthType authType, string username, string password)
    {
        var authAttributes = new AuthAttributes()
        {
            username = username,
            password = password
        };
        var jsonString = JsonConvert.SerializeObject(authAttributes);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(authType.ToString(), jsonString));
    }
    
    public static string CreateRegisterJson(string username, string password)
    {
        return CreateAuthJson(AuthType.register, username, password);
    }
    
    public static string CreateLoginJson(string username, string password)
    {
        return CreateAuthJson(AuthType.auth, username, password);
    }
    
    public class AuthAttributes    {
        public string username { get; set; } 
        public string password { get; set; } 
    }
    
    
}
