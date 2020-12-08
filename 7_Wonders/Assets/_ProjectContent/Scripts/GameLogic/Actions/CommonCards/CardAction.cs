using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class CardAction : Action<CommonCard>
    {
        protected CardAction(CommonCard entity) : base(entity)
        {
        }
        
        public enum Command
        {
            USE,
            ACTIVATED_USE,
            EXCHANGE
        }
    }
}