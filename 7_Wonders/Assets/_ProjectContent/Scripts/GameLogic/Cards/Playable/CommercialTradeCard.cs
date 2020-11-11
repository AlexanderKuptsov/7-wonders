using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialTradeCard : CommercialCard
    {
        [ReadOnly] public Resource.CurrencyItem[] ActionInfo;
        [ReadOnly] public CardActionDirection[] ActionDirection;
        
        public override void Use(PlayerData player)
        {
            throw new System.NotImplementedException();
        }
    }
}