namespace WhiteTeam.GameLogic
{
    public class GameSettings
    {
        public string Name { get; }
        public int MaxPlayers { get; }
        public int MoveTime { get; }

        public GameSettings(string name, int maxPlayers, int moveTime)
        {
            Name = name;
            MaxPlayers = maxPlayers;
            MoveTime = moveTime;
        }
    }
}