using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class SpecialCardWithEndGameEffect<TEffect, TEndGameEffect> : SpecialCard<TEffect>
        where TEffect : CardEffect
        where TEndGameEffect : CardEffect
    {
        public readonly TEndGameEffect EndGameEffect;

        public SpecialCardWithEndGameEffect(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            TEffect currentEffect,
            TEndGameEffect endGameEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
            EndGameEffect = endGameEffect;
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            base.ActivateEndGameEffect(player);
            EndGameEffect?.Activate(player);
        }
    }
}