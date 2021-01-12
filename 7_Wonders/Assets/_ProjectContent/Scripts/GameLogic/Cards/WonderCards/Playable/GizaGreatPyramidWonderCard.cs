using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class GizaGreatPyramidWonderCard : SpecialWonderCard<VictoryEffect, VictoryEffect, VictoryEffect>
    {
        public GizaGreatPyramidWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<VictoryEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, stepBuild1, stepBuild2, stepBuild3)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }

        protected override IWonderVisualizer CreateIwonderVisualizer() => new GizaGreatPyramidVisualizer(this);
    
    }
}