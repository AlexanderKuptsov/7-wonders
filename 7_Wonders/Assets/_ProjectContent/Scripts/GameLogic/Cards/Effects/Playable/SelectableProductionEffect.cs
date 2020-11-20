using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class SelectableProductionEffect : ProductionCardEffect, ISelectableResourceEffect<Resource.CurrencyProducts>
    {
        public SelectableProductionEffect(Resource.CurrencyItem[] actionInfo) : base(actionInfo)
        {
        }

        public Resource.CurrencyBaseData<Resource.CurrencyProducts> Select() // TODO
        {
            throw new System.NotImplementedException();
        }

        public override void Activate(PlayerData player)
        {
            var currencyItem = (Resource.CurrencyItem) Select();
            player.Resources.ChangeProduction(currencyItem);
        }
    }
}