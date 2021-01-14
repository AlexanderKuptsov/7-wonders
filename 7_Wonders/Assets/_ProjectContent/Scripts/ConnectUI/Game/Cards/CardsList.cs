﻿using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Visualization;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class CardsList : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrototype;
        [SerializeField] private Transform cardsHolder;

        public void AddCards(IEnumerable<CommonCard> cards)
        {
            ClearCards(); // TODO
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

        public void AddCard(CommonCard card)
        {
            var cardObject = CardVisualizationController.Instance.Visualize(card, cardPrototype, cardsHolder);
            var playerElement = cardObject.GetComponentInChildren<CardElement>();
            playerElement.Setup(card);
        }
    }
}