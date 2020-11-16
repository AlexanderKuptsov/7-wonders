using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class SpecialWonderCard<TEffect1, TEffect2, TEffect3> : WonderCard // TYPE A (3 steps)
        where TEffect1 : CardEffect
        where TEffect2 : CardEffect
        where TEffect3 : CardEffect
    {
        public SpecialWonderCard(
            string id,
            string name,
            StepBuildWithEffect<TEffect1> stepBuild1,
            StepBuildWithEffect<TEffect2> stepBuild2,
            StepBuildWithEffect<TEffect3> stepBuild3)
            : base(id, name)
        {
            stepBuilds = new StepBuild[] {stepBuild1, stepBuild2, stepBuild3};
        }
    }
}