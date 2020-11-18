using System.Collections.Generic;
using System.Linq;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardsStack
    {
        private static List<Card> Cards;

        private static readonly List<Card> ThrownCards = new List<Card>();

        public static void LoadCards(List<Card> cards)
        {
            Cards = cards;
        }

        public static IEnumerable<Card> GetCards(IEnumerable<string> cardsId)
        {
            return cardsId.Select(GetCard);
        }

        public static Card GetCard(string id)
        {
            NetworkEntity.FindEntityById(Cards, id, out var card);
            return card;
        }

        public static void ThrowCard(Card card)
        {
            ThrownCards.Add(card);
        }

        public static IEnumerable<Card> GetThrownCards()
        {
            return ThrownCards;
        }
    }
}