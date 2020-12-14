﻿using MyBox;
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

        public CardData(string id, string name)
        {
            Id = id;
            Name = name;

            _identifierInfo = new IdentifierInfo(Id, Name);
        }

        protected abstract IVisualizer CreateVisualizer();

        public IVisualizer GetVisualizer()
        {
            return _visualizer ?? (_visualizer = CreateVisualizer());
        }

        public abstract void Use(PlayerData player);
        public abstract void ActivatedUse(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public IdentifierInfo GetIdentifierInfo() => _identifierInfo;
    }
}