using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards
{
    public static class CardCreator
    {
        public static CommonCard Create(CommonCardData data)
        {
            var card = new CommonCard(data);
            return card;
        }

        public static WonderCard Create(WonderCardData data)
        {
            var wonderCard = new WonderCard(data);
            return wonderCard;
        }
    }
}