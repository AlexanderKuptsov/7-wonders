using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class Action
    {
        public Card Card { get; private set; }

        public Action(Card card)
        {
            Card = card;
        }

        public void SendRequest()
        {
            
        }

        protected abstract void SendRequest(Card card, Command command);

        public abstract Command GetCommand();

        public enum Command
        {
            USE,
            EXCHANGE
        }
    }
}