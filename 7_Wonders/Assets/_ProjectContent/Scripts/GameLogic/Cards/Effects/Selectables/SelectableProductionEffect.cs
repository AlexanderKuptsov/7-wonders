using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class SelectableProductionEffect : SelectableCardEffect<Resource.CurrencyItem>
    {
        public SelectableProductionEffect(Resource.CurrencyItem[] actionInfo) : base(actionInfo)
        {
        }

        protected override void DeactivateSelected(PlayerData player)
        {
            player.Resources.SpendProduction(SelectedItem);
        }
        
        protected override void ActivateSelected(PlayerData player)
        {
            player.Resources.AddProduction(SelectedItem);
        }
    }
}