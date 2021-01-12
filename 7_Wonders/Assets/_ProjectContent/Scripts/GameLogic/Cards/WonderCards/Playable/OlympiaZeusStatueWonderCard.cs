using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class
        OlympiaZeusStatueWonderCard : SpecialWonderCard<VictoryEffect, NextEpochEffect<FreeBuildEffect>, VictoryEffect>
        // TODO -- reset free build effect on each epoch
    {
        public OlympiaZeusStatueWonderCard(
            string id, string name,
            StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<NextEpochEffect<FreeBuildEffect>> stepBuild2,
            StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}, stepBuild1,
            stepBuild2, stepBuild3)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }

        protected override IWonderVisualizer CreateIwonderVisualizer() => new OlympiaZeusVisualizer(this);
       
    }
}