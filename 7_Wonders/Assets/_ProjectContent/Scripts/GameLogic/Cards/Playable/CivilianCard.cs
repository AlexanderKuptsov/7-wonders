using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CivilianCard : CardData
    {
        [ReadOnly] public int VictoryPoints;

        public CivilianCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCard,
            int victoryPoints)
            : base(id, name, type, epoch, costInfo, requirementBuildCard)
        {
            VictoryPoints = victoryPoints;
        }

        public override void Use(PlayerData player)
        {
            player.Resources.AddVictory(VictoryPoints);
        }
    }
}