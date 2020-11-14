using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CommercialCard : CardData
    {
        [ReadOnly] public CommercialInfo CommercialType;

        protected CommercialCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            CommercialInfo commercialType)
            : base(id, name, type, epoch, costInfo, requirementBuildCard)
        {
            CommercialType = commercialType;
        }

        public enum CommercialInfo
        {
            MONEY,
            TRADE,
            BONUS
        }
    }
}