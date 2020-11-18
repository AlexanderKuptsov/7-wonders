using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class CardAction : Action<Card>
    {
        protected CardAction(Card entity) : base(entity)
        {
        }
        
        protected enum Command
        {
            USE,
            EXCHANGE
        }
    }
}