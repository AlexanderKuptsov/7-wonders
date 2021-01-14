using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Token
{
    public class TokenHolder : Singleton<TokenHolder>
    {
        public string Token;// { get; private set; }
        public UserData LocalUser; //{ get; private set; }
        
        public Lobby PlayableLobby;// { get; private set; }

        public void SaveToken(string tokenValue)
        {
            Token = tokenValue;
        }

        public void SaveLocalPlayer(UserData localUser)
        {
            LocalUser = localUser;
            LobbyManager.Instance.LocalUserData = LocalUser; // TODO
        }
        
        public void SavePlayableLobby(Lobby lobby)
        {
            PlayableLobby = lobby;
        }

        public bool HasToken() => !string.IsNullOrEmpty(Token);
    }
}