using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class StepBuildWithEffect<TEffect> : StepBuild
        where TEffect : CardEffect
    {
        public readonly TEffect CardEffect;

        public StepBuildWithEffect(Resource.CurrencyItem[] costInfo, TEffect cardEffect) : base(costInfo)
        {
            CardEffect = cardEffect;
        }

        protected override void Activate(PlayerData player)
        {
            CardEffect.Activate(player);
        }
    }
}