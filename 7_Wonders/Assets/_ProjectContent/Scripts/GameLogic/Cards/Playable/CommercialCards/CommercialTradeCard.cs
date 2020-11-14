using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialTradeCard : CommercialCard
    {
        [ReadOnly] public PlayerDirection[] DiscountPlayerDirections;
        [ReadOnly] public Resource.CurrencyProducts[] DiscountResources;
        [ReadOnly] public int DiscountCost;

        public CommercialTradeCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            CommercialInfo commercialType,
            PlayerDirection[] discountPlayerDirections,
            Resource.CurrencyProducts[] discountResources,
            int discountCost)
            : base(id, name, type, epoch, costInfo, requirementBuildCard, commercialType)
        {
            DiscountPlayerDirections = discountPlayerDirections;
            DiscountResources = discountResources;
            DiscountCost = discountCost;
        }

        public override void Use(PlayerData player)
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