using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsStrategyCard : GuildsCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirection;
        [ReadOnly] public int CurrentVictoryBonus;

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).Resources.GetLoseTokens();
                var totalBonus = bonusCardsCount * CurrentVictoryBonus;
                player.Resources.AddVictory(totalBonus);
            }
        }
    }
}