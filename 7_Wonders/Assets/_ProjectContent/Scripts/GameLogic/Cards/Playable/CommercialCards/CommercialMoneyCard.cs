using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialMoneyCard : CommercialCard
    {
        [ReadOnly] public int Coins;

        public CommercialMoneyCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            CommercialInfo commercialType,
            int coins)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, commercialType)
        {
            Coins = coins;
        }

        public override void Use(PlayerData player)
        {
            player.Resources.AddMoney(Coins);
        }
    }
}