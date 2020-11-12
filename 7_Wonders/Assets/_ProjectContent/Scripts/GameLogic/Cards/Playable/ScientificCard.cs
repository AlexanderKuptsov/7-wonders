using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ScientificCard : CardData
    {
        [ReadOnly] public Resource.ScienceItem[] ActionInfo;

        public override void Use(PlayerData player)
        {
            foreach (var currencyItem in ActionInfo)
            {
                player.Resources.AddScience(currencyItem);
            }
        }
    }
}