namespace WhiteTeam.GameLogic.Cards.Effects
{
    public abstract class BaseSelectableCardEffect : CardEffect
    {
        public abstract void Select(PlayerData player);
    }
}