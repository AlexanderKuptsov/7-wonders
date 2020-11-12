namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CommercialCard : CardData
    {
        public CommercialInfo CommercialType;
        
        public enum CommercialInfo
        {
            MONEY,
            TRADE,
            BONUS
        }
    }
}