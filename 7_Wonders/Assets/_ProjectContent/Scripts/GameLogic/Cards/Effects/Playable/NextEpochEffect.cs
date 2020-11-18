namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class NextEpochEffect<TEffect> : CardEffect
        where TEffect : CardEffect
    {
        public TEffect Effect;
        public bool IsRepeatable;
        public bool IsInstant;

        public NextEpochEffect(TEffect effect, bool isRepeatable, bool isInstant)
        {
            Effect = effect;
            IsRepeatable = isRepeatable;
            IsInstant = isInstant;
        }

        public override void Activate(PlayerData player)
        {
            var effectEvent = new EffectEvent {Effect = Effect, IsRepeatable = IsRepeatable};
            player.Events.NextEpochEffects.Add(effectEvent);
            if (IsInstant)
            {
                Effect.Activate(player);
            }
        }
    }
}