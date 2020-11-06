namespace WhiteTeam.Network.Entity
{
    public class IdentifierInfo
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public IdentifierInfo(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}