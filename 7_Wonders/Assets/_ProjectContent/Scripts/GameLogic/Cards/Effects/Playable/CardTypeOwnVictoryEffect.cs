namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class CardTypeOwnVictoryEffect : CardTypeOwnEffect
    {
        public CardTypeOwnVictoryEffect(PlayerDirection[] playerDirection, CardType cardType, int currentMoneyBonus) :
            base(playerDirection, cardType, currentMoneyBonus)
        {
        }

        protected override void ApplyBonus(PlayerData player, int bonus)
        {
            player.Resources.ChangeVictory(bonus);
        }
    }
}