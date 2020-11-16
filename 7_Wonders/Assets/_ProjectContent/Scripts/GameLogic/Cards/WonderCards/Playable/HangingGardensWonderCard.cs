using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class HangingGardensWonderCard : SpecialWonderCard<VictoryEffect, ScienceEffect, VictoryEffect>
        // TODO -- end game selectable science
    {
        public HangingGardensWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<ScienceEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id,
            name, stepBuild1, stepBuild2, stepBuild3)
        {
        }
    }
}