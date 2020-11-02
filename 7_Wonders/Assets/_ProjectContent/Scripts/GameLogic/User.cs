using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic
{
    public class User : INetworkEntity
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        private IdentifierInfo _identifierInfo;

        public User()
        {
            Name = GameParameters.Instance.DefaultUserName;
        }

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Name));
        }
    }
}