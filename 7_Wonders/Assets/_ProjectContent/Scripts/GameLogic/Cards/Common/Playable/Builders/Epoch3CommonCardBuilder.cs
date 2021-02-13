using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class Epoch3CommonCardBuilder : ICommonCardBuilder
    {
        private static string GenerateId()
        {
            return $"{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}";
        }

        public IEnumerable<CommonCardData> CreateRawMaterialsCard()
        {
            var cardsData = new List<CommonCardData>();
            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateProductionCard()
        {
            var cardsData = new List<CommonCardData>();
            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateCivilianCard()
        {
            var cardsData = new[]
            {
                new CivilianCard(
                    GenerateId(),
                    "Pantheon",
                    CommonCardData.CardType.CIVILIAN,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new VictoryEffect(7)),
                new CivilianCard(
                    GenerateId(),
                    "Gardens",
                    CommonCardData.CardType.CIVILIAN,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
                    },
                    "",
                    new VictoryEffect(5)),
                new CivilianCard(
                    GenerateId(),
                    "Town hall",
                    CommonCardData.CardType.CIVILIAN,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new VictoryEffect(6)),
                new CivilianCard(
                    GenerateId(),
                    "Palace",
                    CommonCardData.CardType.CIVILIAN,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1},
                    },
                    "",
                    new VictoryEffect(8)),
                new CivilianCard(
                    GenerateId(),
                    "Palace",
                    CommonCardData.CardType.CIVILIAN,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1}
                    },
                    "",
                    new VictoryEffect(6))
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateMilitaryCard()
        {
            var cardsData = new[]
            {
                new MilitaryCard(
                    GenerateId(),
                    "Fortifications",
                    CommonCardData.CardType.MILITARY,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 3},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(3)),
                new MilitaryCard(
                    GenerateId(),
                    "Circus",
                    CommonCardData.CardType.MILITARY,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 3},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(3)),
                new MilitaryCard(
                    GenerateId(),
                    "Arsenal",
                    CommonCardData.CardType.MILITARY,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(3)),
                new MilitaryCard(
                    GenerateId(),
                    "Siege workshop",
                    CommonCardData.CardType.MILITARY,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 3}
                    },
                    "",
                    new MilitaryEffect(3)),
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateTradeCard()
        {
            var cardsData = new List<CommonCardData>();
            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateScientificCard()
        {
            var cardsData = new[]
            {
                new ScientificCard(
                    GenerateId(),
                    "Lodge",
                    CommonCardData.CardType.SCIENTIFIC,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_1, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "Observatory",
                    CommonCardData.CardType.SCIENTIFIC,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "University",
                    CommonCardData.CardType.SCIENTIFIC,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_3, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "Academy",
                    CommonCardData.CardType.SCIENTIFIC,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 3},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_1, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "Study",
                    CommonCardData.CardType.SCIENTIFIC,
                    3,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1})),
            };

            return cardsData;
        }
    }
}