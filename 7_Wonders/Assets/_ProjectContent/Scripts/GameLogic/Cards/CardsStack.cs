using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardsStack
    {
        private static readonly Dictionary<GameState.EpochType, Queue<Card>>
            Cards = new Dictionary<GameState.EpochType, Queue<Card>>
            {
                {GameState.EpochType.FIRST, new Queue<Card>()},
                {GameState.EpochType.SECOND, new Queue<Card>()},
                {GameState.EpochType.THIRD, new Queue<Card>()}
            };

        private static readonly Dictionary<GameState.EpochType, List<Card>> ThrownCards =
            new Dictionary<GameState.EpochType, List<Card>>
            {
                {GameState.EpochType.FIRST, new List<Card>()},
                {GameState.EpochType.SECOND, new List<Card>()},
                {GameState.EpochType.THIRD, new List<Card>()}
            };

        public static void LoadCards(GameState.EpochType epoch, IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards[epoch].Enqueue(card);
            }
        }

        public static Card TakeCard(GameState.EpochType epoch)
        {
            return Cards[epoch].Dequeue();
        }

        public static void ThrowCard(Card card, GameState.EpochType epoch)
        {
            ThrownCards[epoch].Add(card);
        }

        public static IEnumerable<Card> GetThrownCards(GameState.EpochType epoch)
        {
            return ThrownCards[epoch];
        }
    }
}