using UnityEngine;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardCreator
    {
        public static Card Create(CardData data, Transform parent = null)
        {
            var cardObject = new GameObject(data.Name);
            cardObject.transform.SetParent(parent);

            var card = cardObject.AddComponent<Card>();
            card.Data = data;
            
            return card;
        }
    }
}