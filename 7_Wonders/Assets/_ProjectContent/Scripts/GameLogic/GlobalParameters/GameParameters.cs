using MyBox;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class GameParameters : Singleton<GameParameters>
    {
        [PositiveValueOnly] public int MaxLobbies = 4;
        [PositiveValueOnly] public int MinLobbyUsers = 2;
        [PositiveValueOnly] public int MaxLobbyUsers = 7;
        public string DefaultUserName = "User";

        [PositiveValueOnly] public int MoveTime = 60;
    }
}