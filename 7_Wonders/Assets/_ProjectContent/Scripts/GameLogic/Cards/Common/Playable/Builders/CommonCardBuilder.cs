using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CommonCardBuilder
    {
        // public static CommonCardData CreateRandomCard(string id)
        // {
        //     var builder = new Epoch1CommonCardBuilder();
        //
        //     var rndMethod = Random.Range(0, 6);
        //     switch (rndMethod)
        //     {
        //         case 0:
        //             return builder.CreateRawMaterialsCard(id);
        //         case 1:
        //             return builder.CreateProductionCard(id);
        //         case 2:
        //             return builder.CreateCivilianCard(id);
        //         case 3:
        //             return builder.CreateMilitaryCard(id);
        //         case 4:
        //             return builder.CreateTradeCard(id);
        //         case 5:
        //             return builder.CreateScientificCard(id);
        //         default:
        //             return builder.CreateRawMaterialsCard(id);
        //     }
        // }

        public static IEnumerable<CommonCardData> CreateAllEpochCards()
        {
            var cards = new List<CommonCardData>();
            cards.AddRange(CreateEpochCards(new Epoch1CommonCardBuilder()));
            //cards.AddRange(CreateEpochCards(new Epoch2CommonCardBuilder()));
            //cards.AddRange(CreateEpochCards(new Epoch3CommonCardBuilder()));
            return cards;
        }

        private static IEnumerable<CommonCardData> CreateEpochCards(ICommonCardBuilder builder)
        {
            var cards = new List<CommonCardData>();
            cards.AddRange(builder.CreateRawMaterialsCard());
            cards.AddRange(builder.CreateProductionCard());
            cards.AddRange(builder.CreateCivilianCard());
            cards.AddRange(builder.CreateMilitaryCard());
            cards.AddRange(builder.CreateTradeCard());
            cards.AddRange(builder.CreateScientificCard());

            return cards;
        }
    }
}