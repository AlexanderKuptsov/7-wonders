using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public abstract class CardAction : Action<Card>
    {
        protected Card _card { get; }

        public CardAction(Card card)
        {
            _card = card;
        }

        protected enum Command
        {
            USE,
            EXCHANGE
        }
    }
}