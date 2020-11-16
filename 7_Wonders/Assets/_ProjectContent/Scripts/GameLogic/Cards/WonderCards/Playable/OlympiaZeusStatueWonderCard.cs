using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class OlympiaZeusStatueWonderCard : SpecialWonderCard<VictoryEffect, FreeBuildEffect, VictoryEffect>
        // TODO -- reset free build effect on each epoch
    {
        public OlympiaZeusStatueWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<FreeBuildEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, stepBuild1, stepBuild2, stepBuild3)
        {
        }
    }
}