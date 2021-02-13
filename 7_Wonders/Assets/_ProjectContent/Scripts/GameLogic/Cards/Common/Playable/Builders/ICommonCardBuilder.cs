using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Cards
{
    public interface ICommonCardBuilder
    {
        IEnumerable<CommonCardData> CreateRawMaterialsCard();
        IEnumerable<CommonCardData> CreateProductionCard();
        IEnumerable<CommonCardData> CreateCivilianCard();
        IEnumerable<CommonCardData> CreateMilitaryCard();
        IEnumerable<CommonCardData> CreateTradeCard();
        IEnumerable<CommonCardData> CreateScientificCard();
    }
}