using UnityEngine;
using WhiteTeam.GameLogic.Actions;
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

        public void Use()
        {
            var action = GetAction();
            GameManager.Instance.PlayerActionRequest(action);
        }

        protected abstract Action GetAction();
    }
}