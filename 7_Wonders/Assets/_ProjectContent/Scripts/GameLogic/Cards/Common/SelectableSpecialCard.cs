using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class SelectableSpecialCard<TEffect> : SpecialCard<TEffect>
        where TEffect : BaseSelectableCardEffect
    {
        protected SelectableSpecialCard(string id, string name, CardType type, int epoch,
            Resource.CurrencyItem[] costInfo, string requirementBuildCardId, TEffect currentEffect) : base(id, name,
            type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override void ActivatedUseAction(PlayerData player)
        {
            base.ActivatedUseAction(player);
            Select(player);
        }

        private void Select(PlayerData player)
        {
            CurrentEffect.Select(player);
        }
    }
}