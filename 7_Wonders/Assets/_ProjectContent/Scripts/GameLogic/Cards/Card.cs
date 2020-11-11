using UnityEngine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class Card : MonoBehaviour
    {
        [SerializeField] private CardData data;

        public CardData Data
        {
            get => data;
            set => data = value;
        }

        #region NETWORK REQUESTS

        public void ExchangeRequest()
        {
            var action = new ExchangeAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        public void UseRequest()
        {
            var action = new UseAction(this);
            GameManager.Instance.PlayerActionRequest(action);
        }

        #endregion

        #region ACTIONS

        public void Exchange(PlayerData player)
        {
            player.ThrowCard(this);
            player.Resources.AddMoney(RulesParameters.Instance.CardExchangeAmount);
        }

        public void Use(PlayerData player)
        {
            player.ActivateCard(this);
            UseAction(player);
        }

        protected abstract void UseAction(PlayerData player);

        #endregion
    }
}