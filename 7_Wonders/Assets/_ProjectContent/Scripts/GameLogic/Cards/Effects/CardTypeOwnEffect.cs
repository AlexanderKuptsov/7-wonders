namespace WhiteTeam.GameLogic.Cards.Effects
{
    public abstract class CardTypeOwnEffect : CardEffect
    {
        public readonly PlayerDirection[] PlayerDirection;
        public readonly CardType CardType;
        public readonly int CurrentMoneyBonus;

        public CardTypeOwnEffect(PlayerDirection[] playerDirection, CardType cardType, int currentMoneyBonus)
        {
            PlayerDirection = playerDirection;
            CardType = cardType;
            CurrentMoneyBonus = currentMoneyBonus;
        }

        public override void Activate(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).GetActiveCardCountByType(CardType);
                var totalBonus = bonusCardsCount * CurrentMoneyBonus;
                ApplyBonus(player, totalBonus);
            }
        }

        protected abstract void ApplyBonus(PlayerData player, int bonus);
    }
}