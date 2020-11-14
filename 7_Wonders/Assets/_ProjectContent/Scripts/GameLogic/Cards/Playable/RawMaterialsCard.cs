using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class RawMaterialsCard : CardData
    {
        [ReadOnly] public Resource.CurrencyItem[] ActionInfo;

        public RawMaterialsCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            Resource.CurrencyItem[] actionInfo)
            : base(id, name, type, epoch, costInfo, requirementBuildCard)
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