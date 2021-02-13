using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class Epoch2CommonCardBuilder : ICommonCardBuilder
    {
        
        private static string GenerateId()
        {
            return $"{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}";
        }
        public IEnumerable<CommonCardData> CreateRawMaterialsCard()
        {
            var cardsData = new[]
            {
                new RawMaterialsCard(
                    GenerateId(),
                    "Sawmill",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                    },
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Quarry",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                    },
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Brickyard",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                    },
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Foundry",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                    },
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2}
                    })),
                
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateProductionCard()
        {
            var cardsData = new[]
            {
                new ProductionCard(
                    GenerateId(),
                    "Loom",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    })),
                new ProductionCard(
                    GenerateId(),
                    "Glassworks",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    })),
                new ProductionCard(
                    GenerateId(),
                    "Press",
                    CommonCardData.CardType.PRODUCTION,
                    2,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1}
                    }))
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateCivilianCard()
        {
            var cardsData = new[]
            {
                new CivilianCard(
                    GenerateId(),
                    "Aqueduct",
                    CommonCardData.CardType.CIVILIAN,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 3}
                    },
                    "",
                    new VictoryEffect(5)),
                new CivilianCard(
                    GenerateId(),
                    "Temple",
                    CommonCardData.CardType.CIVILIAN,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                    },
                    "",
                    new VictoryEffect(3)),
                new CivilianCard(
                    GenerateId(),
                    "Statue",
                    CommonCardData.CardType.CIVILIAN,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                    },
                    "",
                    new VictoryEffect(4)),
                new CivilianCard(
                    GenerateId(),
                    "Courthouse",
                    CommonCardData.CardType.CIVILIAN,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1},
                    },
                    "",
                    new VictoryEffect(4)),
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateMilitaryCard()
        {
            var cardsData = new[]
            {
                new MilitaryCard(
                    GenerateId(),
                    "Walls",
                    CommonCardData.CardType.MILITARY,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 3}
                    },
                    "",
                    new MilitaryEffect(2)),
                new MilitaryCard(
                    GenerateId(),
                    "Training Ground",
                    CommonCardData.CardType.MILITARY,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(2)),
                new MilitaryCard(
                    GenerateId(),
                    "Stables",
                    CommonCardData.CardType.MILITARY,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(2)),
                new MilitaryCard(
                    GenerateId(),
                    "Archery Range",
                    CommonCardData.CardType.MILITARY,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(2)),
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
                    "Dispensary",
                    CommonCardData.CardType.SCIENTIFIC,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_1, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "Laboratory",
                    CommonCardData.CardType.SCIENTIFIC,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1})),
                new ScientificCard(
                    GenerateId(),
                    "Library",
                    CommonCardData.CardType.SCIENTIFIC,
                    2,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 1}
                    },
                    "",
                    new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_3, Amount = 1})),
                new ScientificCard(
                GenerateId(),
                "School",
                CommonCardData.CardType.SCIENTIFIC,
                2,
                new[]
                {
                    new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                    new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1}
                },
                "",
                new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_3, Amount = 1}))

            };

            return cardsData;
        }
    }
}