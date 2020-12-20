using MyBox;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CardData : INetworkEntity
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;

        private IdentifierInfo _identifierInfo;

        private IVisualizer _visualizer;

        private IWonderVisualizer _wonder_visualizer;

        public CardData(string id, string name)
        {
            Id = id;
            Name = name;

            _identifierInfo = new IdentifierInfo(Id, Name);
        }

        protected abstract IVisualizer CreateVisualizer();

        protected abstract IWonderVisualizer CreateWonderVisualizer();

        public IVisualizer GetVisualizer()
        {
            return _visualizer ?? (_visualizer = CreateVisualizer());
        }

          public IWonderVisualizer GetWonderVisualizer()
        {
            return _wonder_visualizer ?? (_wonder_visualizer = CreateWonderVisualizer());
        }

        public abstract void Use(PlayerData player);
        public abstract void ActivatedUse(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public IdentifierInfo GetIdentifierInfo() => _identifierInfo;
    }
}