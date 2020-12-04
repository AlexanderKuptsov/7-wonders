using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Actions
{
    public class WonderCardBuildAction : WonderCardAction
    {
        public WonderCardBuildAction(WonderCard entity) : base(entity)
        {
        }

        protected override void SendRequest(WonderCard entity, string command)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCommand() => Command.BUILD.ToString();
    }
}