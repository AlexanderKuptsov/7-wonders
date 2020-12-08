using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Effects
{
    public class SelectableScienceEffect : SelectableCardEffect<Resource.ScienceItem>
    {
        public SelectableScienceEffect() : base(
            new[]
            {
                new Resource.ScienceItem {Currency = Resource.Science.RUNE_1, Amount = 1},
                new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1},
                new Resource.ScienceItem {Currency = Resource.Science.RUNE_3, Amount = 1}
            })
        {
        }

        protected override void DeactivateSelected(PlayerData player)
        {
            player.Resources.SpendScience(SelectedItem);
        }

        protected override void ActivateSelected(PlayerData player)
        {
            player.Resources.AddScience(SelectedItem);
        }
    }
}