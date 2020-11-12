namespace WhiteTeam.GameLogic.Cards
{
    public abstract class GuildsCard : CardData
    {
        public GuildsInfo GuildsType;
        
        public enum  GuildsInfo
        {
            OWNING,
            STRATEGY,
            SCIENCE
        }
    }
}