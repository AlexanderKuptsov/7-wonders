using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class GizaGreatPyramidWonderCard : SpecialWonderCard<VictoryEffect, VictoryEffect, VictoryEffect>
    {
        public GizaGreatPyramidWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<VictoryEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, stepBuild1, stepBuild2, stepBuild3)
        {
        }
    }
}