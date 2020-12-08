using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Actions
{
    public class WonderCardActivatedUseAction : WonderCardAction
    {
        public WonderCardActivatedUseAction(WonderCard entity) : base(entity)
        {
        }

        protected override void SendRequest(WonderCard entity, string command)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCommand() => Command.ACTIVATED_USE.ToString();
    }
}