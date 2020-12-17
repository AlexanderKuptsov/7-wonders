using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.ServerModules;

namespace WhiteTeam.GameLogic.Actions
{
    public class WonderCardActivatedUseAction : WonderCardAction
    {
        public WonderCardActivatedUseAction(WonderCard entity) : base(entity)
        {
        }

        protected override void SendRequest(WonderCard card, string command)
        {
            ServerGameHandler.Instance.CardActionRequest(GameManager.Instance.CurrentSession.gameId,card.Data.Id, command);
        }

        public override string GetCommand() => Command.ACTIVATED_USE.ToString();
    }
}