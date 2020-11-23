using System.Collections.Generic;
using System.Linq;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardsStack
    {
        private static List<CommonCard> Cards;

        private static readonly List<CommonCard> ThrownCards = new List<CommonCard>();

        public static void LoadCards(List<CommonCard> cards)
        {
            Cards = cards;
        }

        public static IEnumerable<CommonCard> GetCards(IEnumerable<string> cardsId)
        {
            return cardsId.Select(GetCard);
        }

        public static CommonCard GetCard(string id)
        {
            NetworkEntity.FindEntityById(Cards, id, out var card);
            return card;
        }

        public static void ThrowCard(CommonCard card)
        {
            ThrownCards.Add(card);
        }

        public static IEnumerable<CommonCard> GetThrownCards()
        {
            return ThrownCards;
        }
    }
}