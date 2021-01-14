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
                    return CreateCivilianCard(id);
                case 1:
                    return CreateCivilianCard(id);
                case 2:
                    return CreateCivilianCard(id);
                case 3:
                    return CreateCivilianCard(id);
                case 4:
                    return CreateCivilianCard(id);
                case 5:
                    return CreateScientificCard(id);
                case 6:
                    return CreateScientificCard(id);
                default:
                    return CreateScientificCard(id);
            }
        }

        private static CivilianCard CreateCivilianCard(string id)
        {
            var cardsData = new[]
            {
                new CivilianCard(
                    id,
                    "Pawnshop",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(3)),
                new CivilianCard(
                    id,
                    "Baths",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1}
                    },
                    "",
                    new VictoryEffect(3)),
                new CivilianCard(
                    id,
                    "Altar",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(2)),
                new CivilianCard(
                    id,
                    "Theater",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(2)),
            };

            return cardsData[Random.Range(0, cardsData.Length)];
        }

        private static ScientificCard CreateScientificCard(string id)
        {
            var cardsData = new[]
            {
                new ScientificCard(
                    id,
                    "Apothecary",
                    CommonCardData.CardType.SCIENTIFIC,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_1, Amount = 1})),
                new ScientificCard(
                    id,
                    "Workshop",
                    CommonCardData.CardType.SCIENTIFIC,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1})),
                new ScientificCard(
                    id,
                    "Scriptorium",
                    CommonCardData.CardType.SCIENTIFIC,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_3, Amount = 1}))
            };

            return cardsData[Random.Range(0, cardsData.Length)];
        }
    }
}