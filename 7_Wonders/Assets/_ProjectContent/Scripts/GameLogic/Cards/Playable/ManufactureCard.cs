using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ManufactureCard : SpecialCard<ProductionCardEffect>
    {
        public ManufactureCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, ProductionCardEffect currentEffect) : base(id, name, type, epoch, costInfo,
            requirementBuildCardId, currentEffect)
        {
        }
    }
}