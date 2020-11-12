using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialTradeCard : CommercialCard
    {
        [ReadOnly] public PlayerDirection[] DiscountPlayerDirection;
        [ReadOnly] public Resource.CurrencyProducts[] DiscountResources;
        [ReadOnly] public int DiscountCost;

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in DiscountPlayerDirection)
            {
                foreach (var discountResource in DiscountResources)
                {
                    player.ResourcesBuyCost.SetCost(playerDirection, discountResource, DiscountCost);
                }
            }
        }
    }
}