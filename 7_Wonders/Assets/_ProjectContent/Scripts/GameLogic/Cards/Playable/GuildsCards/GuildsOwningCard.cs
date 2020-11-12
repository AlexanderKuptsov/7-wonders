using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsOwningCard : GuildsCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirection;
        [ReadOnly] public CardType CardType;
        [ReadOnly] public int CurrentVictoryBonus;

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).GetActiveCardCountByType(CardType);
                var totalBonus = bonusCardsCount * CurrentVictoryBonus;
                player.Resources.AddVictory(totalBonus);
            }
        }
    }
}