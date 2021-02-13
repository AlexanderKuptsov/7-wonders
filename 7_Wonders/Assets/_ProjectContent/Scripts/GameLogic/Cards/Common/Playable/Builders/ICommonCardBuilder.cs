using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Cards
{
    public interface ICommonCardBuilder
    {
        IEnumerable<RawMaterialsCard> CreateRawMaterialsCard();
        IEnumerable<ProductionCard> CreateProductionCard();
        IEnumerable<CivilianCard> CreateCivilianCard();
        IEnumerable<MilitaryCard> CreateMilitaryCard();
        IEnumerable<CommercialMoneyCard> CreateTradeCard();
        IEnumerable<ScientificCard> CreateScientificCard();
    }
}