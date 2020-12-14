using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardCreator
    {
        public static CommonCard Create(CommonCardData data, Transform parent = null)
        {
            var cardObject = new GameObject(data.Name);
            cardObject.transform.SetParent(parent);

            var card = cardObject.AddComponent<CommonCard>();
            card.Data = data;

            //CardVisualizationController.Instance.AddVisualizer(card); TODO

            return card;
        }

        public static WonderCard Create(WonderCardData data, Transform parent = null)
        {
            var cardObject = new GameObject(data.Name);
            cardObject.transform.SetParent(parent);

            var card = cardObject.AddComponent<WonderCard>();
            card.Data = data;

            //CardVisualizationController.Instance.AddVisualizer(card); TODO

            return card;
        }
    }
}