namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class CardTypeOwnMoneyEffect : CardTypeOwnEffect
    {
        public CardTypeOwnMoneyEffect(PlayerDirection[] playerDirection, CommonCardData.CardType cardType, int currentMoneyBonus)
            : base(playerDirection, cardType, currentMoneyBonus)
        {
        }

        protected override void ApplyBonus(PlayerData player, int bonus)
        {
            player.Resources.ChangeMoney(bonus);
        }
    }
}