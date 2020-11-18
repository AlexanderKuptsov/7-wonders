using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public class ExchangeAction : CardAction
    {
        public ExchangeAction(Card card) : base(card)
        {
        }

        protected override void SendRequest(Card card, string command)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCommand() => Command.EXCHANGE.ToString();
    }
}