namespace WhiteTeam.GameLogic.Cards.Effects
{
    public abstract class CardEffect : ICardEffect
    {
        public abstract void Activate(PlayerData player);
    }
}