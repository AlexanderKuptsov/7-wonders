using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class NoTradeSelectableProductionEffect : SelectableProductionEffect
    {
        public NoTradeSelectableProductionEffect(Resource.CurrencyItem[] actionInfo) : base(actionInfo)
        {
        }

        protected override void DeactivateSelected(PlayerData player)
        {
            player.Resources.RemoveNoTradeProduction(SelectedItem);
        }

        protected override void ActivateSelected(PlayerData player)
        {
            player.Resources.EarnNoTradeProduction(SelectedItem);
        }
    }
}