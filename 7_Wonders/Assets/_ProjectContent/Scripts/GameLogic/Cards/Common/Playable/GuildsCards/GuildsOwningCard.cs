using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsOwningCard : GuildsCard<CardTypeOwnVictoryEffect, CardTypeOwnVictoryEffect>
    {
        public GuildsOwningCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, CardTypeOwnVictoryEffect currentEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }
    }
}