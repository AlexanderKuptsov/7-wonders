using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class CollossWonderCard : SpecialWonderCard<VictoryEffect, MilitaryEffect, VictoryEffect>
    {
        public CollossWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<MilitaryEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, stepBuild1, stepBuild2, stepBuild3)
        {
        }

        protected override IVisualizer CreateVisualizer()
        {
            throw new System.NotImplementedException();
        }
    }
}