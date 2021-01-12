using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class CardElement : MonoBehaviour
    {
        public CommonCard Card { get; private set; }

        public void Setup(CommonCard card)
        {
            Card = card;
            Create();
        }

        private void Create()
        {
            var cardObject = CardVisualizationController.Instance.Visualize(Card);
            cardObject.transform.SetParent(transform);
            cardObject.transform.position = Vector3.zero; // TODO
        }
    }
}