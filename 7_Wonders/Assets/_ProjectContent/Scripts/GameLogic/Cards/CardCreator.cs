using System;
using SK_Engine;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards
{
    public class CardCreator
    {
        public Card Create(string cardTypeName, CardData data, Transform parent = null)
        {
            var cardType = AssistanceFunctions.GetEnumByName<Type>(cardTypeName);
            var cardObject = new GameObject(cardTypeName);
            cardObject.transform.SetParent(parent);

            switch (cardType)
            {
                case Type.WONDER:
                    cardObject.AddComponent<WonderCard>();
                    break;
                case Type.TODO:
                    cardObject.AddComponent<WonderCard>(); // TODO
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var card = cardObject.GetComponent<Card>();
            card.Data = data;
            
            return card;
        }

        public enum Type
        {
            WONDER,
            TODO
        }
    }
}