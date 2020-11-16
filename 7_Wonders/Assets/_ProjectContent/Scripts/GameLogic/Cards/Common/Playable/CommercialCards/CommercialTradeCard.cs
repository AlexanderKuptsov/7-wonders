using MyBox;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialTradeCard : CommercialCard<TradeEffect, TradeEffect>
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
            string requirementBuildCardId,
            CommercialInfo commercialType,
            PlayerDirection[] discountPlayerDirections,
            Resource.CurrencyProducts[] discountResources,
            int discountCost,
            TradeEffect tradeEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, commercialType, tradeEffect)
        {
            DiscountPlayerDirections = discountPlayerDirections;
            DiscountResources = discountResources;
            DiscountCost = discountCost;
        }
    }
}