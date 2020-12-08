using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class WonderCard : CardWrapper<WonderCardData>
    {
        #region NETWORK REQUESTS

        public override void UseRequest()
        {
            var action = new WonderCardBuildAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        public override void ActivatedUseRequest()
        {
            var action = new WonderCardActivatedUseAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        #endregion

        #region ACTIONS

        public override void Use(PlayerData player)
        {
            throw new System.NotImplementedException();
        }

        public override void ActivatedUse(PlayerData player)
        {
            throw new System.NotImplementedException();
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}