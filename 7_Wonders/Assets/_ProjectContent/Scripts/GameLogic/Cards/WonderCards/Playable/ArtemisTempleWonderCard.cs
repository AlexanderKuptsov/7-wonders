using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class ArtemisTempleWonderCard : SpecialWonderCard<VictoryEffect, MoneyEffect, VictoryEffect>
    {
        public ArtemisTempleWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<MoneyEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id, name,
            stepBuild1, stepBuild2, stepBuild3)
        {
        }
    }
}