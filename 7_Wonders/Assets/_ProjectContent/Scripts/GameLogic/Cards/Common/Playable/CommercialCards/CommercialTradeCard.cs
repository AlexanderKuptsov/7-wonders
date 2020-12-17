using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialTradeCard : CommercialCard<TradeEffect, TradeEffect>
    {
        public CommercialTradeCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            TradeEffect tradeEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, tradeEffect)
        {
        }

        protected override IVisualizer CreateVisualizer() => new CommercialTradeVisualizer(this);
    
   }  
}