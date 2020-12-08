using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class
        AlexandriaLighthouseWonderCard : SpecialWonderCard<VictoryEffect, NoTradeSelectableProductionEffect,
            VictoryEffect>
    {
        public AlexandriaLighthouseWonderCard(string id, string name, StepBuildWithEffect<VictoryEffect> stepBuild1,
            StepBuildWithEffect<NoTradeSelectableProductionEffect> stepBuild2,
            StepBuildWithEffect<VictoryEffect> stepBuild3) : base(id, name, stepBuild1, stepBuild2, stepBuild3)
        {
        }

        public override void ActivatedUse(PlayerData player)
        {
            base.ActivatedUse(player);
            var bonusBuildEffect = SecondStepBuild;
            if (!bonusBuildEffect.IsCompleted) return;
            bonusBuildEffect.CardEffect.Select(player);
        }
    }
}