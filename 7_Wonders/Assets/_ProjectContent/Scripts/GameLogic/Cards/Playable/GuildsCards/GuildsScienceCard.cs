using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsScienceCard : GuildsCard
    {
        private Resource.Science _selectedScience;

        public override void Use(PlayerData player) // TODO -- select
        {
            throw new System.NotImplementedException();
        }

        public void Select(Resource.Science science)
        {
            _selectedScience = science;
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
            player.Resources.AddScience(new Resource.ScienceItem {Currency = _selectedScience, Amount = 1});
        }
    }
}