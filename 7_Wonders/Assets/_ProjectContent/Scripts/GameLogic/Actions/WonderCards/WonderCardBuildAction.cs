using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.ServerModules;

namespace WhiteTeam.GameLogic.Actions
{
    public class WonderCardBuildAction : WonderCardAction
    {
        public WonderCardBuildAction(WonderCard entity) : base(entity)
        {
        }

        protected override void SendRequest(WonderCard card, string command)
        {
            ServerGameHandler.Instance.CardActionRequest(GameManager.Instance.CurrentSession.gameId,card.Data.Id, command);
        }

        public override string GetCommand() => Command.BUILD.ToString();
    }
}