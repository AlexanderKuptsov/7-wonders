namespace WhiteTeam.GameLogic
{
    public class GameSettings
    {
        public string Name { get; private set; }
        public int MaxPlayers { get; private set; }
        public int MoveTime { get; private set; }

        public GameSettings(string name, int maxPlayers, int moveTime)
        {
            Name = name;
            MaxPlayers = maxPlayers;
            MoveTime = moveTime;
        }
    }
}