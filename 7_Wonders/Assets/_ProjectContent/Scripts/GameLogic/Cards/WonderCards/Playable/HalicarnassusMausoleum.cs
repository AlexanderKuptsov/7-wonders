using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class HalicarnassusMausoleum : SpecialWonderCard<VictoryEffect, ThrownCardOverviewEffect, VictoryEffect>
        // TODO -- thrown effect
    {
        public HalicarnassusMausoleum(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<ThrownCardOverviewEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) :
            base(id, name, new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1},
                stepBuild1, stepBuild2, stepBuild3)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }
        protected override IWonderVisualizer CreateIwonderVisualizer() => new HalicarnassusMausoleumVisualizer(this);
       
    }
}