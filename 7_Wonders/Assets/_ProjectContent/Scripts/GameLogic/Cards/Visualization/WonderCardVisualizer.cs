using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public abstract class WonderCardVisualizer<TCardData>
        where TCardData : WonderCard
    {
        protected TCardData cardData;

        public WonderCardVisualizer(TCardData data)
        {
            cardData = data;
        }

        public abstract Color GetColor();
        public abstract Sprite GetBackground();
        public abstract Image GetCurrentEffect();
        public abstract Image GetEnGameEffect();
    }
}