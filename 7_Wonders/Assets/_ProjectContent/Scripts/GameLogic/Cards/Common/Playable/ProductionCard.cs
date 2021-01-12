using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ProductionCard : SpecialCard<ProductionCardEffect>
    {
        public ProductionCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, ProductionCardEffect currentEffect) : base(id, name, type, epoch, costInfo,
            requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer()=> new ProductionVisualizer(this);
         protected override IWonderVisualizer CreateIwonderVisualizer()
        {
            throw new System.NotImplementedException();
        }
       
    }
}