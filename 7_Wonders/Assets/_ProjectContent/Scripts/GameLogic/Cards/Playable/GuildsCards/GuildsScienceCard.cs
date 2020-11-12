using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsScienceCard : GuildsCard
    {
        [ReadOnly] public Resource.Science SelectedScience;

        public override void Use(PlayerData player) // TODO -- select
        {
            throw new System.NotImplementedException();
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            player.Resources.AddScience(new Resource.ScienceItem {Currency = SelectedScience, Amount = 1});
        }
    }
}