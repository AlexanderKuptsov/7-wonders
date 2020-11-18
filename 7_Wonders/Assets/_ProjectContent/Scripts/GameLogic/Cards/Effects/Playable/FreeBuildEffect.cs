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
            var freeBuildTokens = player.Resources.GetFreeBuildTokens();
            if (freeBuildTokens < FreeBuildAmount)
            {
                var remainingFreeBuildTokens = FreeBuildAmount - freeBuildTokens;
                player.Resources.ChangeFreeBuildTokens(remainingFreeBuildTokens);
            }
        }
    }
}