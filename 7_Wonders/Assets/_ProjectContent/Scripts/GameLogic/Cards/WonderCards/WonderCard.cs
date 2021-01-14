using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public class WonderCard : CardWrapper<WonderCardData>
    {
        public WonderCard(WonderCardData data) : base(data)
        {
        }

        #region NETWORK REQUESTS

        public override void UseRequest()
        {
            if (Data.CanBuildCurrentStep(LocalPlayer))
            {
                var action = new WonderCardBuildAction(this);
                GameManager.Instance.PlayerActionRequest(action);
            }
            else
            {
                OnErrorEvent.TriggerEvents("Not enough money"); // TODO   
            }
        }

        public override void ActivatedUseRequest()
        {
            var action = new WonderCardActivatedUseAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        #endregion

        #region ACTIONS

        public void Build(PlayerData player, CommonCard cardToThrow)
        {
            Data.Build(player, cardToThrow);
            player.CompleteMove();
        }
        
        public override void Use(PlayerData player)
        {
            Data.Use(player);
            player.CompleteMove();
        }

        public override void ActivatedUse(PlayerData player)
        {
            Data.ActivatedUse(player);
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            Data.ActivateEndGameEffect(player);
        }

        #endregion
    }
}