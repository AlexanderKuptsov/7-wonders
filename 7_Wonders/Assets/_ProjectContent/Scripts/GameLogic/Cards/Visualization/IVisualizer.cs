using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public interface IVisualizer
    {
        Color GetColor();
        Image GetCurrentEffect();
        Image GetEnGameEffect();
    }
}