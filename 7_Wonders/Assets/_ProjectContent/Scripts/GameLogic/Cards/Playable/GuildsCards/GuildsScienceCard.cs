using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsScienceCard : GuildsCard
    {
        private Resource.Science _selectedScience;

        public GuildsScienceCard(
            string id,
            string name,
            CardType type,
            int epoch,
            Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId,
            GuildsInfo guildsType,
            Resource.Science selectedScience)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, guildsType)
        {
            _selectedScience = selectedScience;
        }

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