using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions

{
    public class UseAction : CardAction
    {
        public UseAction(Card card) : base(card)
        {
        }

        protected override void SendRequest(Card entity, string command)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCommand() => Command.USE.ToString();
    }
}