using UnityEngine;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public static class WonderCardsBuilder
    {
        public static CollossWonderCard CreateColloss(string id)
            => new CollossWonderCard(
                id,
                "The Colossus of Rhodes",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<MilitaryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 3},
                    },
                    new MilitaryEffect(2)),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 4},
                    },
                    new VictoryEffect(7)));

        public static AlexandriaLighthouseWonderCard CreateAlexandriaLighthouse(string id)
            => new AlexandriaLighthouseWonderCard(
                id,
                "The Lighthouse of Alexandria",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<NoTradeSelectableProductionEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                    },
                    new NoTradeSelectableProductionEffect(new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 1},
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1},
                    })),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 2},
                    },
                    new VictoryEffect(7)));

        public static ArtemisTempleWonderCard CreateArtemisTemple(string id)
            => new ArtemisTempleWonderCard(
                id,
                "The Temple of Artemis in Ephesus",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<MoneyEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                    },
                    new MoneyEffect(9)),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 2},
                    },
                    new VictoryEffect(7)));

        public static HangingGardensWonderCard CreateHangingGardens(string id)
            => new HangingGardensWonderCard(
                id,
                "The Hanging Gardens of Babylon",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<SelectableScienceEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 3},
                    },
                    new SelectableScienceEffect()),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 4},
                    },
                    new VictoryEffect(7)));

        public static OlympiaZeusStatueWonderCard CreateZeusStatue(string id)
            => new OlympiaZeusStatueWonderCard(
                id,
                "The Statue of Zeus in Olympia",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<NextEpochEffect<FreeBuildEffect>>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                    },
                    new NextEpochEffect<FreeBuildEffect>(new FreeBuildEffect(1), true, true)),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 2},
                    },
                    new VictoryEffect(7)));

        public static HalicarnassusMausoleum CreateHalicarnassusMausoleum(string id)
            => new HalicarnassusMausoleum(
                id,
                "The Mausoleum of Halicarnassus",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLAY, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<ThrownCardOverviewEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 4},
                    },
                    new ThrownCardOverviewEffect()),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.CLOTH, Amount = 2},
                    },
                    new VictoryEffect(7)));

        public static GizaGreatPyramidWonderCard CreateGizaGreatPyramid(string id)
            => new GizaGreatPyramidWonderCard(
                id,
                "The Pyramids of Giza",
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 2},
                    },
                    new VictoryEffect(3)),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 4},
                    },
                    new VictoryEffect(5)),
                new StepBuildWithEffect<VictoryEffect>(
                    new[]
                    {
                        new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 4},
                    },
                    new VictoryEffect(7)));
    }
}