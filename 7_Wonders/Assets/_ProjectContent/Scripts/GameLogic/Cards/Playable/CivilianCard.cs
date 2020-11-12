using MyBox;

namespace WhiteTeam.GameLogic.Cards
{
    public class CivilianCard : CardData
    {
        [ReadOnly] public int VictoryPoints;
        
        public override void Use(PlayerData player)
        {
            player.Resources.AddVictory(VictoryPoints);
        }
    }
}