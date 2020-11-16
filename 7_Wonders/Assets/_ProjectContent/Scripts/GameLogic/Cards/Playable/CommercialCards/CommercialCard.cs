using MyBox;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class
        CommercialCard<TEffect, TEndGameEffect> : SpecialCardWithEndGameEffect<TEffect, TEndGameEffect>
        where TEffect : CardEffect
        where TEndGameEffect : CardEffect
    {
        [ReadOnly] public readonly CommercialInfo CommercialType;

        protected CommercialCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            CommercialInfo commercialType,
            TEffect currentEffect,
            TEndGameEffect endGameEffect = null)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect, endGameEffect)
        {
            CommercialType = commercialType;
        }

        public enum CommercialInfo
        {
            MONEY,
            TRADE,
            BONUS
        }
    }
}