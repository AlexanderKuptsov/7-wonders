using MyBox;

namespace WhiteTeam.GameLogic.Token
{
    public class TokenHolder : Singleton<TokenHolder>
    {
        [ReadOnly] public string Token;

        public void CreateToken(string tokenValue)
        {
            Token = tokenValue;
        }

        public bool HasToken() => !string.IsNullOrEmpty(Token);
    }
}