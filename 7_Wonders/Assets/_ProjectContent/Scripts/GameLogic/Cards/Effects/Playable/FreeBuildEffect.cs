namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class FreeBuildEffect : CardEffect
    {
        public readonly int FreeBuildAmount;

        public FreeBuildEffect(int freeBuildAmount)
        {
            FreeBuildAmount = freeBuildAmount;
        }

        public override void Activate(PlayerData player)
        {
            player.Resources.AddFreeBuildTokens(FreeBuildAmount);
        }
    }
}