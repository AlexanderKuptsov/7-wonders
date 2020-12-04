using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class WonderCardAction : Action<WonderCard>
    {
        protected WonderCardAction(WonderCard entity) : base(entity)
        {
        }
        
        protected enum Command
        {
            BUILD,
            ACTIVATED_USE,
        }
    }
}