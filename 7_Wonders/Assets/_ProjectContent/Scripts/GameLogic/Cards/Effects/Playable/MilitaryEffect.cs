namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class MilitaryEffect : CardEffect
    {
        public readonly int Shields;

        public MilitaryEffect(int shields)
        {
            Shields = shields;
        }

        public override void Activate(PlayerData player)
        {
            player.Resources.ChangeMilitary(Shields);
        }
    }
}