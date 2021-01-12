using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class SelectableProductionCard : SelectableSpecialCard<SelectableProductionEffect>
    {
        public SelectableProductionCard(string id, string name, CardType type, int epoch,
            Resource.CurrencyItem[] costInfo, string requirementBuildCardId, SelectableProductionEffect currentEffect) :
            base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }
         protected override IWonderVisualizer CreateIwonderVisualizer()
        {
            throw new System.NotImplementedException();
        }
    }
}