using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ScientificCard : CardData
    {
        [ReadOnly] public Resource.ScienceItem[] ActionInfo;

        public ScientificCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            Resource.ScienceItem[] actionInfo)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId)
        {
            ActionInfo = actionInfo;
        }

        public override void Use(PlayerData player)
        {
            foreach (var currencyItem in ActionInfo)
            {
                player.Resources.AddScience(currencyItem);
            }
        }
    }
}