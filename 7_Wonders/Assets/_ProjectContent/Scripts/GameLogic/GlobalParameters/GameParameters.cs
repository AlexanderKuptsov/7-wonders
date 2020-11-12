using MyBox;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class GameParameters : Singleton<GameParameters>
    {
        [PositiveValueOnly] public int MaxLobbies = 4;
        [PositiveValueOnly] public int MinLobbyUsers = 2;
        [PositiveValueOnly] public int MaxLobbyUsers = 7;
        public string DefaultUserName = "User";

        [PositiveValueOnly] public int DefaultMoveTime = 60;

        public StartResources DefaultResources = new StartResources
        {
            Money = 3,
            Science = 0,
            War = 0,
            Victory = 0,
            Conflict = 0,
            LoseTokens = 0
        };

        public struct StartResources
        {
            public int Money;
            public int Science;
            public int War;
            public int Victory;
            public int Conflict;
            public int LoseTokens;
        }
    }
}