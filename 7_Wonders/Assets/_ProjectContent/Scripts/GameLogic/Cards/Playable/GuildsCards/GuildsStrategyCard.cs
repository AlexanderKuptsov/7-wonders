using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsStrategyCard : GuildsCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirection;
        [ReadOnly] public int CurrentVictoryBonus;

        public GuildsStrategyCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            GuildsInfo guildsType,
            PlayerDirection[] playerDirection,
            int currentVictoryBonus)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, guildsType)
        {
            PlayerDirection = playerDirection;
            CurrentVictoryBonus = currentVictoryBonus;
        }

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