namespace WhiteTeam.Network
{
    public class IdentifierInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public IdentifierInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}