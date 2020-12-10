using SK_Engine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommonCard : CardWrapper<CommonCardData>
    {
        #region NETWORK REQUESTS

        public void ExchangeRequest()
        {
            var action = new ExchangeAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        public override void UseRequest()
        {
            if (Data.CanBuy(LocalPlayer))
            {
                var action = new UseAction(this);
                GameManager.Instance.PlayerActionRequest(action);
            }
            else
            {
                OnErrorEvent.TriggerEvents("Not enough money"); // TODO   
            }
        }

        public override void ActivatedUseRequest()
        {
            var action = new ActivatedUseAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        #endregion

        #region ACTIONS

        public void Exchange(PlayerData player)
        {
            player.ThrowCard(this);
            player.Resources.ChangeMoney(RulesParameters.Instance.CardExchangeAmount);
            player.CompleteMove();
        }

        public override void Use(PlayerData player)
        {
            player.ActivateCard(this);
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