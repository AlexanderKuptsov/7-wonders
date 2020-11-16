using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsScienceCard : GuildsCard<ScienceEffect, ScienceEffect> // TODO -- currentEffect - selection
    {
        public void Select(Resource.Science science)
        {
            EndGameEffect.ScienceInfo.Currency = science;
        }

        public GuildsScienceCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, GuildsInfo guildsType, ScienceEffect currentEffect,
            ScienceEffect endGameEffect) : base(id, name, type, epoch, costInfo, requirementBuildCardId, guildsType,
            currentEffect, endGameEffect)
        {
        }
    }
}