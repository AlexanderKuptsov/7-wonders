using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions

{
    public class UseAction : Action
    {
        public UseAction(Card card) : base(card)
        {
        }

        public override Command GetCommand() => Command.USE;
    }
}