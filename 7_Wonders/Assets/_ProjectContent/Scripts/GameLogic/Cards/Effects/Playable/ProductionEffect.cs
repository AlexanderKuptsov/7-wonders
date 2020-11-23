using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class ProductionCardEffect : CardEffect
    {
        public readonly Resource.CurrencyItem[] ActionInfo;

        public ProductionCardEffect(Resource.CurrencyItem[] actionInfo)
        {
            ActionInfo = actionInfo;
        }

        public override void Activate(PlayerData player)
        {
            foreach (var currencyItem in ActionInfo)
            {
                player.Resources.AddProduction(currencyItem);
            }
        }
    }
}