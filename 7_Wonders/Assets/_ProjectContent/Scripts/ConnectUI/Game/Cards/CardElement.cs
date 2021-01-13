using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class CardElement : MonoBehaviour
    {
        public CommonCard Card { get; private set; }

        private GameObject _cardObject;

        public void Setup(CommonCard card)
        {
            Card = card;
        }
    }
}