using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public abstract class CardWonderVisualizer<TCardData> : IWonderVisualizer
        where TCardData : WonderCardData
    {
        protected TCardData cardData;
        public Sprite Cost = null;

        public CardWonderVisualizer(TCardData data)
        {
            cardData = data;
        }

        public string GetNameCard()
        {
            return cardData.Name;
        }


        public abstract Sprite GetBackground();
        public abstract Sprite GetCostFirstEra();
        public abstract Sprite GetCostSecondEra();
        public abstract Sprite GetCostThirdEra();
        public abstract Sprite GetInitialBonus();
        public abstract Sprite GetCurrentEffectStepTwo();
    }
}