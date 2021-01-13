namespace WhiteTeam.GameLogic.Token
{
    public class TokenHolder : Singleton<TokenHolder>
    {
        public string Token { get; private set; }
        public UserData LocalUser { get; private set; }

        public void SaveToken(string tokenValue)
        {
            Token = tokenValue;
        }

        public void SaveLocalPlayer(UserData localUser)
        {
            LocalUser = localUser;
            LobbyManager.Instance.LocalUserData = LocalUser; // TODO
        }

        public bool HasToken() => !string.IsNullOrEmpty(Token);
    }
}