using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class GuildsCard<TEffect, TEndGameEffect> : SpecialCardWithEndGameEffect<TEffect, TEndGameEffect>
        where TEffect : CardEffect
        where TEndGameEffect : CardEffect
    {
        public readonly GuildsInfo GuildsType;

        protected GuildsCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, GuildsInfo guildsType, TEffect currentEffect,
            TEndGameEffect endGameEffect = null)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect, endGameEffect)
        {
            GuildsType = guildsType;
        }

        public enum GuildsInfo
        {
            OWNING,
            STRATEGY,
            SCIENCE
        }
    }
}