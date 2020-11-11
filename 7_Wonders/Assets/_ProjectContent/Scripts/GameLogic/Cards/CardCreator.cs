using System;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards
{
    public class CardCreator
    {
        public Card Create(CardData data, Transform parent = null)
        {
            var cardObject = new GameObject(data.Name);
            cardObject.transform.SetParent(parent);

            switch (data.Type)
            {
                case CardType.WONDER:
                    cardObject.AddComponent<WonderCard>();
                    break;
                case CardType.RAW_MATERIALS:
                    cardObject.AddComponent<RawMaterialsCard>();
                    break;
                case CardType.MANUFACTURE:
                    cardObject.AddComponent<ManufactureCard>();
                    break;
                case CardType.CIVILIAN:
                    cardObject.AddComponent<CivilianCard>();
                    break;
                case CardType.SCIENTIFIC:
                    cardObject.AddComponent<ScientificCard>();
                    break;
                case CardType.COMMERCIAL:
                    cardObject.AddComponent<CommercialCard>();
                    break;
                case CardType.MILITARY:
                    cardObject.AddComponent<MilitaryCard>();
                    break;
                case CardType.GUILDS:
                    cardObject.AddComponent<GuildsCard>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var card = cardObject.GetComponent<Card>();
            card.Data = data;
            
            return card;
        }
    }
}