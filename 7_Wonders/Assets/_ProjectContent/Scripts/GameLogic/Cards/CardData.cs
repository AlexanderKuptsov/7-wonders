using MyBox;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CardData : INetworkEntity
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;

        private IdentifierInfo _identifierInfo;

        public CardData(string id, string name)
        {
            Id = id;
            Name = name;

            _identifierInfo = new IdentifierInfo(Id, Name);
        }

        public abstract void Use(PlayerData player);
        public abstract void ActivatedUse(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public IdentifierInfo GetIdentifierInfo() => _identifierInfo;
    }
}