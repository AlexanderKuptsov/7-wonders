using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class TradeEffect : CardEffect
    {
        public readonly PlayerDirection[] DiscountPlayerDirections;
        public readonly Resource.CurrencyProducts[] DiscountResources;
        public readonly int DiscountCost;

        public TradeEffect(
            PlayerDirection[] discountPlayerDirections,
            Resource.CurrencyProducts[] discountResources,
            int discountCost)
        {
            DiscountPlayerDirections = discountPlayerDirections;
            DiscountResources = discountResources;
            DiscountCost = discountCost;
        }

        public override void Activate(PlayerData player)
        {
            foreach (var playerDirection in DiscountPlayerDirections)
            {
                foreach (var discountResource in DiscountResources)
                {
                    player.ResourcesBuyCost.SetCost(playerDirection, discountResource, DiscountCost);
                }
            }
        }
    }
}