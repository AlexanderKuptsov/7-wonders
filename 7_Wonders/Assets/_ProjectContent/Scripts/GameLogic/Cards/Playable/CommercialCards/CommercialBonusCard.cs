using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialBonusCard : CommercialCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirection;
        [ReadOnly] public CardType CardType;
        [ReadOnly] public int CurrentMoneyBonus;
        [ReadOnly] public int EndGameVictoryBonus;

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).GetActiveCardCountByType(CardType);
                var totalBonus = bonusCardsCount * CurrentMoneyBonus;
                player.Resources.AddMoney(totalBonus);
            }
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            base.ActivateEndGameEffect(player);
            player.Resources.AddVictory(EndGameVictoryBonus);
        }
    }
}