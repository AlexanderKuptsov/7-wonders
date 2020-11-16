using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class CommercialBonusCard : CommercialCard<CardTypeOwnMoneyEffect, VictoryEffect>
    {
        public CommercialBonusCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, CommercialInfo commercialType, CardTypeOwnMoneyEffect currentEffect,
            VictoryEffect endGameEffect) : base(id, name, type, epoch, costInfo, requirementBuildCardId,
            commercialType, currentEffect, endGameEffect)
        {
        }
    }
}