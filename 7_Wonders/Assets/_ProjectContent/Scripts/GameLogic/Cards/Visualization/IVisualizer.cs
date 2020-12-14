using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public interface IVisualizer
    {
        Color GetColor();
        Sprite GetBackground();
        Sprite GetCurrentEffect();
        Sprite GetEnGameEffect();
    }
}