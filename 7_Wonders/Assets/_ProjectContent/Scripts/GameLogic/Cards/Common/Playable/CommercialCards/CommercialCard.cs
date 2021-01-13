using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CommercialCard<TEffect, TEndGameEffect> : SpecialCardWithEndGameEffect<TEffect, TEndGameEffect>
        where TEffect : CardEffect
        where TEndGameEffect : CardEffect
    {
        protected CommercialCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            TEffect currentEffect,
            TEndGameEffect endGameEffect = null)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect, endGameEffect)
        {
        }
    }
}