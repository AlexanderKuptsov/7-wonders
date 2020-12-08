namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class VictoryEffect : CardEffect
    {
        public readonly int VictoryPoints;

        public VictoryEffect(int victoryPoints)
        {
            VictoryPoints = victoryPoints;
        }

        public override void Activate(PlayerData player)
        {
            player.Resources.ChangeVictory(VictoryPoints);
        }
    }
}