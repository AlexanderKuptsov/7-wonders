using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class Epoch1CommonCardBuilder : ICommonCardBuilder
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
                    "Lumber Yard",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Stone pit",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Clay pool",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1}
                    })),
                new RawMaterialsCard(
                    GenerateId(),
                    "Ore vein",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                    })),
                
                new RawMaterialsCard(
                GenerateId(),
                "Tree Farm",
                CommonCardData.CardType.PRODUCTION,
                1,
                new[]
                {
                    new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                },
                "",
                new ProductionCardEffect(new[]
                {
                    new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                })),
                (CommonCardData) new SelectableProductionCard(
                    GenerateId(),
                    "Excavation",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.MONEY, Amount = 1}
                    },
                    "",
                    new SelectableProductionEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
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
                    1,
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
                    1,
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
                    1,
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
                    "Pawnshop",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(3)),
                new CivilianCard(
                    GenerateId(),
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
                    GenerateId(),
                    "Altar",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(2)),
                new CivilianCard(
                    GenerateId(),
                    "Theater",
                    CommonCardData.CardType.CIVILIAN,
                    1,
                    null,
                    "",
                    new VictoryEffect(2)),
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateMilitaryCard()
        {
            var cardsData = new[]
            {
                new MilitaryCard(
                    GenerateId(),
                    "Stockade",
                    CommonCardData.CardType.MILITARY,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(1)),
                new MilitaryCard(
                    GenerateId(),
                    "Barracks",
                    CommonCardData.CardType.MILITARY,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(1)),
                new MilitaryCard(
                    GenerateId(),
                    "Guard tower",
                    CommonCardData.CardType.MILITARY,
                    1,
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1}
                    },
                    "",
                    new MilitaryEffect(1)),
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateTradeCard()
        {
            var cardsData = new[]
            {
                new CommercialMoneyCard(
                    GenerateId(),
                    "Tavern",
                    CommonCardData.CardType.COMMERCIAL_MONEY,
                    1,
                    null,
                    "",
                    new MoneyEffect(1)),
            };

            return cardsData;
        }

        public IEnumerable<CommonCardData> CreateScientificCard()
        {
            var cardsData = new[]
            {
                new ScientificCard(
                    GenerateId(),
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
                    GenerateId(),
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
                    GenerateId(),
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

            return cardsData;
        }
    }
}