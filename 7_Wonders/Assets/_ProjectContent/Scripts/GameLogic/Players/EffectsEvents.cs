using System.Collections.Generic;
using System.Linq;
using WhiteTeam.GameLogic.Cards.Effects;

namespace WhiteTeam.GameLogic
{
    public class EffectsEvents
    {
        public readonly EffectsHolder NextMoveEffects = new EffectsHolder();
        public readonly EffectsHolder NextEpochEffects = new EffectsHolder();
        public readonly EffectsHolder EndGameEffects = new EffectsHolder();

        public class EffectsHolder
        {
            private List<EffectEvent> _effects = new List<EffectEvent>();

            public void Add(EffectEvent effectEvent)
            {
                _effects.Add(effectEvent);
            }

            public void Trigger(PlayerData player)
            {
                foreach (var effectEvent in _effects)
                {
                    effectEvent.Effect.Activate(player);
                }

                if (_effects.Count > 0 && _effects.Any(effectEvent => !effectEvent.IsRepeatable))
                {
                    _effects = _effects.Where(effectEvent => effectEvent.IsRepeatable).ToList();
                }
            }
        }
    }
}