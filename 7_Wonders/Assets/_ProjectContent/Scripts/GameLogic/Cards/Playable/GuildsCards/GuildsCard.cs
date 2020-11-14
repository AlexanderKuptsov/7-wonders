using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class GuildsCard : CardData
    {
        public GuildsInfo GuildsType;

        protected GuildsCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            GuildsInfo guildsType)
            : base(id, name, type, epoch, costInfo, requirementBuildCard)
        {
            GuildsType = guildsType;
        }

        public enum GuildsInfo
        {
            OWNING,
            STRATEGY,
            SCIENCE
        }
    }
}