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

        public abstract Color GetColor();
        public abstract Image GetCurrentEffect();
        public abstract Image GetEnGameEffect();
    }
}