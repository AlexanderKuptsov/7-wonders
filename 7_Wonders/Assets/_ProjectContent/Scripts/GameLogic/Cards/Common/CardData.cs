using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyBox;
using WhiteTeam.GameLogic.Resources;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    [Serializable]
    public abstract class CardData : INetworkEntity
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;
        [ReadOnly] public CardType Type;
        [ReadOnly] public int Epoch;
        [ReadOnly] public Resource.CurrencyItem[] CostInfo;
        [ReadOnly] public string RequirementBuildCardId; // TODO

        private IdentifierInfo _identifierInfo;

        public CardData(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId)
        {
            Id = id;
            Name = name;
            Type = type;
            Epoch = epoch;
            CostInfo = costInfo;
            RequirementBuildCardId = requirementBuildCardId;

            _identifierInfo = new IdentifierInfo(Id, Name);
        }

        public abstract void Use(PlayerData player);

        public virtual void ActivateEndGameEffect(PlayerData player)
        {
        }

        public void Buy(PlayerData player)
        {
            if (player.FindActiveCardById(RequirementBuildCardId, out var foundCard))
            {
                return;
            }

            foreach (var currencyItem in CostInfo)
            {
                player.Resources.Buy(currencyItem);
            }
        }

        public void UseFreeBuyToken(PlayerData player)
        {
            player.Resources.ChangeFreeBuildTokens(-1);
        }

        public bool CanBuy(PlayerData player)
        {
            // Check special requirement for free card activation 
            if (player.FindActiveCardById(RequirementBuildCardId, out var foundCard))
            {
                return true;
            }

            // Check player for card activation requirement resources
            var haveEnoughResources = CostInfo.All(currencyItem => player.Resources.HasEnoughCurrency(currencyItem));
            return haveEnoughResources;
        }

        public bool HasFreeBuildToken(PlayerData player) => player.Resources.GetFreeBuildTokens() > 0;

        public IEnumerable<PropertyInfo> GetSelfProperties()
        {
            return Assembly
                .GetAssembly(typeof(CardData))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CardData))).SelectMany(t => t.GetProperties());
        }

        public IdentifierInfo GetIdentifierInfo() => _identifierInfo;
    }

    public enum CardType
    {
        RAW_MATERIALS,
        MANUFACTURE,
        CIVILIAN,
        SCIENTIFIC,
        COMMERCIAL,
        MILITARY,
        GUILDS
    }
}