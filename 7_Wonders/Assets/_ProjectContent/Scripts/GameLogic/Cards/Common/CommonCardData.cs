using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    [Serializable]
    public abstract class CommonCardData : CardData
    {
        [ReadOnly] public CardType Type;
        [ReadOnly] public int Epoch;
        [ReadOnly] public Resource.CurrencyItem[] CostInfo;
        [ReadOnly] public string RequirementBuildCardId;

        private bool _isActivated;

        public CommonCardData(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId) : base(id, name)
        {
            Type = type;
            Epoch = epoch;
            CostInfo = costInfo;
            RequirementBuildCardId = requirementBuildCardId;
        }

        public override void ActivatedUse(PlayerData player)
        {
            if (!_isActivated) return;
            ActivatedUseAction(player);
        }

        protected virtual void ActivatedUseAction(PlayerData player)
        {
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
        }

        public void Activate()
        {
            _isActivated = true;
        }

        public void Buy(PlayerData player)
        {
            if (player.FindActiveCardById(RequirementBuildCardId, out var foundCard) || CostInfo == null)
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
            if (CostInfo == null) return true;

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
                .GetAssembly(typeof(CommonCardData))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CommonCardData))).SelectMany(t => t.GetProperties());
        }

        public enum CardType
        {
            PRODUCTION,
            CIVILIAN,
            SCIENTIFIC,
            MILITARY,

            COMMERCIAL_MONEY,
            COMMERCIAL_TRADE,
            COMMERCIAL_BONUS,

            GUILDS_OWNING,
            GUILDS_STRATEGY,
            GUILDS_SCIENCE
        }
    }
}