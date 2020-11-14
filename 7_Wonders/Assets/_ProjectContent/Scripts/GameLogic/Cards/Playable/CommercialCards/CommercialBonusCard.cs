using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialBonusCard : CommercialCard
    {
        [ReadOnly] public PlayerDirection[] PlayerDirection;
        [ReadOnly] public CardType BonusCardType;
        [ReadOnly] public int CurrentMoneyBonus;
        [ReadOnly] public int EndGameVictoryBonus;

        public CommercialBonusCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            CommercialInfo commercialType,
            PlayerDirection[] playerDirection,
            CardType bonusCardType,
            int currentMoneyBonus,
            int endGameVictoryBonus)
            : base(id, name, type, epoch, costInfo, requirementBuildCard, commercialType)
        {
            PlayerDirection = playerDirection;
            BonusCardType = bonusCardType;
            CurrentMoneyBonus = currentMoneyBonus;
            EndGameVictoryBonus = endGameVictoryBonus;
        }

        public override void Use(PlayerData player)
        {
            foreach (var playerDirection in PlayerDirection)
            {
                var bonusCardsCount = player.GetNeighborByDirection(playerDirection)
                    .GetActiveCardCountByType(BonusCardType);
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