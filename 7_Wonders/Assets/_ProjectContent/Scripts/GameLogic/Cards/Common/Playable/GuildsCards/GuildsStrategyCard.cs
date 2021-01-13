using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsStrategyCard : GuildsCard<StrategyEffect, StrategyEffect>
    {
        public GuildsStrategyCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, StrategyEffect currentEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer()=> new GuildsStrategyVisualizer(this);
         protected override IWonderVisualizer CreateIwonderVisualizer()
        {
            throw new System.NotImplementedException();
        }
       
    }
}