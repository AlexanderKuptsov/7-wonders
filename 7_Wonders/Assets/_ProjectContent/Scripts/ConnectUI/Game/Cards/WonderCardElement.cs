using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class WonderCardElement : MonoBehaviour
    {
        public WonderCard Card { get; private set; }

        private GameObject _cardObject;

        public void Setup(WonderCard card)
        {
            Card = card;
        }
    }
}