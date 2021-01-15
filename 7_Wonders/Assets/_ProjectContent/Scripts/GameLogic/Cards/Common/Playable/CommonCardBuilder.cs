using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CommonCardBuilder
    {
        public static CommonCardData CreateRandomCard(string id)
        {
            var rndMethod = Random.Range(0, 6);
            switch (rndMethod)
            {
                case 0:
                    return CreateRawMaterialsCard(id);
                case 1:
                    return CreateProductionCard(id);
                case 2:
                    return CreateCivilianCard(id);
                case 3:
                    return CreateMilitaryCard(id);
                case 4:
                    return CreateTradeCard(id);
                case 5:
                    return CreateScientificCard(id);
                default:
                    return CreateRawMaterialsCard(id);
            }
        }

        private static RawMaterialsCard CreateRawMaterialsCard(string id)
        {
            var cardsData = new[]
            {
                new RawMaterialsCard(
                    id,
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
                    id,
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
                    id,
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
                    id,
                    "Ore vein",
                    CommonCardData.CardType.PRODUCTION,
                    1,
                    null,
                    "",
                    new ProductionCardEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
                    }))
            };

            return cardsData[Random.Range(0, cardsData.Length)];
        }

        private static ProductionCard CreateProductionCard(string id)
        {
            var cardsData = new[]
            {
                new ProductionCard(
                    id,
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
                    id,
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
                    id,
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

            return cardsData[Random.Range(0, cardsData.Length)];
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

        private static MilitaryCard CreateMilitaryCard(string id)
        {
            var cardsData = new[]
            {
                new MilitaryCard(
                    id,
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
                    id,
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
                    id,
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

            return cardsData[Random.Range(0, cardsData.Length)];
        }

        private static CommercialMoneyCard CreateTradeCard(string id)
        {
            var cardsData = new[]
            {
                new CommercialMoneyCard(
                    id,
                    "Tavern",
                    CommonCardData.CardType.COMMERCIAL_MONEY,
                    1,
                    null,
                    "",
                    new MoneyEffect(1)),
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