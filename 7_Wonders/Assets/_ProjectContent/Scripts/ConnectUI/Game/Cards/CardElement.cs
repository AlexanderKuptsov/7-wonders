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
            Create();
        }

        private void Create()
        {
            var cardVisualObject = CardVisualizationController.Instance.Visualize(Card);
            _cardObject = Instantiate(cardVisualObject, transform);
            // _cardObject.transform.position = Vector3.zero; // TODO
        }
    }
}