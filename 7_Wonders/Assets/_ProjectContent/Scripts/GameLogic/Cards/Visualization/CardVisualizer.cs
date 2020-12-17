using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public abstract class CardVisualizer<TCardData> : IVisualizer
        where TCardData : CommonCardData
    {
        protected TCardData cardData;

        public CardVisualizer(TCardData data)
        {
            cardData = data;
        }
        
        public abstract string GetNameCard();
        public abstract Color GetColor();
        public abstract Sprite GetCost();
        public abstract Sprite GetBackground();
        public abstract Sprite GetCurrentEffect();
        public abstract Sprite GetEndGameEffect();
    }
}