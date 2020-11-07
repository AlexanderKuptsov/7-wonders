using UnityEngine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic.Cards
{
    public class CardWrapper : MonoBehaviour
    {
        public Card Card;

        public void Use()
        {
            var action = GetAction();
            GameManager.Instance.PlayerActionRequest(action);
        }

        protected virtual Action GetAction() => Card.Use();
    }
}