using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class
        GuildsScienceCard : GuildsCard<SelectableScienceEffect, ScienceEffect> // TODO -- currentEffect - selection
    {
        private bool _isSelected;

        public void Select(Resource.Science science)
        {
            EndGameEffect.ScienceInfo.Currency = science;
        }

        public GuildsScienceCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, SelectableScienceEffect currentEffect) :
            base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override void ActivatedUseAction(PlayerData player)
        {
            base.ActivatedUseAction(player);
            if (_isSelected) return;
            Select(player);
        }

        private void Select(PlayerData player)
        {
            CurrentEffect.Select(player);
            _isSelected = true;
        }
    }
}