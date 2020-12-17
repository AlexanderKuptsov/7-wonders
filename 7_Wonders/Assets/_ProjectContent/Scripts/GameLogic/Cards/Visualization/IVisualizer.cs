using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public interface IVisualizer
    {
        string GetNameCard();
        Color GetColor();
        Sprite GetCost();
        Sprite GetBackground();
        Sprite GetCurrentEffect();
        Sprite GetEndGameEffect();
    }
}