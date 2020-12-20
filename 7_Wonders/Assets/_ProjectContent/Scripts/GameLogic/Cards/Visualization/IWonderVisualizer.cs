using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public interface IWonderVisualizer
    {
        string GetNameCard();
        Color GetColor();
        Sprite GetBackground();
        Sprite GetCostFirstEra();
        Sprite GetCostSecondEra();
        Sprite GetCostThirdEra();
        Sprite GetInitialBonus();
        Sprite GetCurrentEffect();
        
    }
}