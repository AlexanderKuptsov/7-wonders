using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public class ExchangeAction : Action
    {
        public ExchangeAction(Card card) : base(card)
        {
        }

        protected override void SendRequest(Card card, Command command)
        {
            throw new System.NotImplementedException();
        }

        public override Command GetCommand() => Command.EXCHANGE;
    }
}