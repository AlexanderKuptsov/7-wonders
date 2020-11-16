using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class
        AlexandriaLighthouseWonderCard : SpecialWonderCard<VictoryEffect, ProductionCardEffect, VictoryEffect>
        // TODO - Selectable production / no trade resource
    {
        public AlexandriaLighthouseWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<ProductionCardEffect> stepBuild2, StepBuildWithEffect<VictoryEffect> stepBuild3) : base(
            id, name, stepBuild1, stepBuild2, stepBuild3)
        {
        }
    }
}