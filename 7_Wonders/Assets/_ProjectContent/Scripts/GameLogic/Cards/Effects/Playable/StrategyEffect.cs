namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class StrategyEffect : CardEffect
    {
        public readonly PlayerDirection[] PlayerDirection;
        public readonly int CurrentVictoryBonus;

        public StrategyEffect(PlayerDirection[] playerDirection, int currentVictoryBonus)
        {
            PlayerDirection = playerDirection;
            CurrentVictoryBonus = currentVictoryBonus;
        }

        public override void Activate(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).Resources.GetWarLoseTokens();
                var totalBonus = bonusCardsCount * CurrentVictoryBonus;
                player.Resources.ChangeVictory(totalBonus);
            }
        }
    }
}