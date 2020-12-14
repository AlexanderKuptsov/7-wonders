using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class HalicarnassusMausoleum : SpecialWonderCard<VictoryEffect, ThrownCardOverviewEffect, VictoryEffect>
        // TODO -- thrown effect
    {
        public HalicarnassusMausoleum(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<ThrownCardOverviewEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) :
            base(id, name, stepBuild1, stepBuild2, stepBuild3)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }
    }
}