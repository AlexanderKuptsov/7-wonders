using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class WonderCardAction : Action<WonderCard>
    {
        protected WonderCardAction(WonderCard entity) : base(entity)
        {
        }
        
        public enum Command
        {
            BUILD,
            ACTIVATED_USE,
        }
    }
}