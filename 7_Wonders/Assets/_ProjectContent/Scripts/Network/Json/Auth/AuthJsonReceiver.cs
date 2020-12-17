namespace Network.Json
{
    public class AuthJsonReceiver : JsonReceiverBase<AuthResult, AuthJsonReceiver>
    {
    }

    public class AuthResult : Result
    {
        public TokenInfo results { get; set; }
    }

    public class TokenInfo
    {
        public string nickname {get; set;}
        public string accessToken { get; set; }
        public string tokenType { get; set; } 
    }
}