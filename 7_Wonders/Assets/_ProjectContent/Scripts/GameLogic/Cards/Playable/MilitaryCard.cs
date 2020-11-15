using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class MilitaryCard : CardData
    {
        [ReadOnly] public int Shields;

        public MilitaryCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            int shields) : base(id, name, type, epoch, costInfo, requirementBuildCardId)
        {
            Shields = shields;
        }

        public override void Use(PlayerData player)
        {
            player.Resources.AddMilitary(Shields);
        }
    }
}