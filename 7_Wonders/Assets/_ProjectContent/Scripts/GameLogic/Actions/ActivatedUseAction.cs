using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.GameLogic.Actions
{
    public class ActivatedUseAction : CardAction
    {
        public ActivatedUseAction(CommonCard entity) : base(entity)
        {
        }

        protected override void SendRequest(CommonCard entity, string command)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCommand() => Command.ACTIVATED_USE.ToString();
    }
}