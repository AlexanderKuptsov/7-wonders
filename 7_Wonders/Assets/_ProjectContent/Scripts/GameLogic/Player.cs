namespace WhiteTeam.GameLogic
{
    public class Player : User
    {
        public Role Role { get; private set; }

        public Player LeftPlayer { get; private set; }
        public Player RightPlayer { get; private set; }

        private Player(int id, string name) : base(id, name)
        {
        }

        public Player(int id, string name, Role role) : base(id, name)
        {
            Role = role;
        }

        public void MakeAdmin()
        {
            Role = Role.ADMIN;
        }

        public void MakeClient()
        {
            Role = Role.CLIENT;
        }

        public void SeatBetween(Player leftPlayer, Player rightPlayer)
        {
            LeftPlayer = leftPlayer;
            RightPlayer = rightPlayer;
        }

        public static Player CreateFromUser(User user)
        {
            var player = new Player(user.Id, user.Name);
            return player;
        }
    }
}