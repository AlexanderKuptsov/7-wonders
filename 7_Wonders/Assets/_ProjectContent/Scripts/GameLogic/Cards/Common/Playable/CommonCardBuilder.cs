using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CommonCardBuilder
    {
        public static CommonCardData CreateRandomCard(string id)
        {
            var rndMethod = Random.Range(0, 7);
            switch (rndMethod)
            {
                case 0:
                    return CreateScientificCard(id);
                case 1:
                    return CreateScientificCard(id);
                case 2:
                    return CreateScientificCard(id);
                case 3:
                    return CreateScientificCard(id);
                case 4:
                    return CreateScientificCard(id);
                case 5:
                    return CreateScientificCard(id);
                case 6:
                    return CreateScientificCard(id);
                default:
                    return CreateScientificCard(id);
            }
        }

        public static ScientificCard CreateScientificCard(string id)
        {
            var cardData = new ScientificCard(
                id,
                "Science",
                CommonCardData.CardType.COMMERCIAL_TRADE,
                1,
                new[]
                {
                    new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                },
                "",
                new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1}));

            return cardData;
        }
    }
}