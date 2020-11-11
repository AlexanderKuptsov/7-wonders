using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public class ExchangeAction : Action
    {
        public ExchangeAction(Card card) : base(card)
        {
        }

        public override Command GetCommand() => Command.EXCHANGE;
    }
}