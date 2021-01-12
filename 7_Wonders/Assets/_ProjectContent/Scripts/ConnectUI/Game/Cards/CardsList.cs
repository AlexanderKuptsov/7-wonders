using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class CardsList : Singleton<CardsList>
    {
        [SerializeField] private GameObject cardElement;
        [SerializeField] private Transform cardsHolder;

        public void AddCards(IEnumerable<CommonCard> cards)
        {
            foreach (var card in cards)
            {
                AddCard(card);
            }
        }

        public void ClearCards()
        {
            for (var i = 0; i < cardsHolder.childCount; i++)
            {
                Destroy(cardsHolder.GetChild(i).gameObject);
            }
        }

        private void AddCard(CommonCard card)
        {
            var cardObject = Instantiate(cardElement.gameObject, cardsHolder);
            var playerElement = cardObject.GetComponent<CardElement>();
            playerElement.Setup(card);
        }
    }
}