using UnityEngine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class Card : MonoBehaviour, INetworkEntity
    {
        public CardData Data;

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
            player.Resources.ChangeMoney(RulesParameters.Instance.CardExchangeAmount);
        }

        public void Use(PlayerData player)
        {
            player.ActivateCard(this);
            Data.Use(player);
        }

        public void ActivateEndGameEffect(PlayerData player)
        {
            Data.ActivateEndGameEffect(player);
        }

        #endregion

        public IdentifierInfo GetIdentifierInfo() => Data.GetIdentifierInfo();
    }
}