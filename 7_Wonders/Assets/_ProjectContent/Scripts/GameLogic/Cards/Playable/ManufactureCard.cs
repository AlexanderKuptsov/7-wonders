using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ManufactureCard : CardData
    {
        [ReadOnly] public Resource.CurrencyItem[] ActionInfo;

        public ManufactureCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            Resource.CurrencyItem[] actionInfo)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId)
        {
            ActionInfo = actionInfo;
        }

        public override void Use(PlayerData player)
        {
            foreach (var currencyItem in ActionInfo)
            {
                player.Resources.AddProduction(currencyItem);
            }
        }
    }
}