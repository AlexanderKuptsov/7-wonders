using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsOwningCard : GuildsCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirections;
        [ReadOnly] public CardType CardType;
        [ReadOnly] public int CurrentVictoryBonus;

        public GuildsOwningCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            GuildsInfo guildsType,
            PlayerDirection[] playerDirections,
            CardType cardType,
            int currentVictoryBonus)
            : base(id, name, type, epoch, costInfo, requirementBuildCard, guildsType)
        {
            PlayerDirections = playerDirections;
            CardType = cardType;
            CurrentVictoryBonus = currentVictoryBonus;
        }

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirections)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection).GetActiveCardCountByType(CardType);
                var totalBonus = bonusCardsCount * CurrentVictoryBonus;
                player.Resources.AddVictory(totalBonus);
            }
        }
    }
}