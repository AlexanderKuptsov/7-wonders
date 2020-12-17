using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialMoneyCard : CommercialCard<MoneyEffect, MoneyEffect>
    {
        public CommercialMoneyCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, MoneyEffect currentEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer()=>new CommercialMoneyVisualizer(this);
        
    }
}