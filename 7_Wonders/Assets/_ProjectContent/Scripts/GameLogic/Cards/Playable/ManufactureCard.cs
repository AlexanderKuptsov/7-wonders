using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ManufactureCard : CardData
    {
        [ReadOnly] public Resource.CurrencyItem[] ActionInfo;
        
        public override void Use(PlayerData player)
        {
            foreach (var currencyItem in ActionInfo)
            {
                player.Resources.AddProduction(currencyItem);
            }
        }
    }
}