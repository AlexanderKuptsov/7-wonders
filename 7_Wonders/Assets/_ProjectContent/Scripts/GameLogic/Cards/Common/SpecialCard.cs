using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class SpecialCard<TEffect> : CommonCardData
        where TEffect : CardEffect
    {
        public TEffect CurrentEffect;

        public SpecialCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            TEffect currentEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId)
        {
            CurrentEffect = currentEffect;
        }

        public override void Use(PlayerData player)
        {
            CurrentEffect?.Activate(player);
        }
    }
}