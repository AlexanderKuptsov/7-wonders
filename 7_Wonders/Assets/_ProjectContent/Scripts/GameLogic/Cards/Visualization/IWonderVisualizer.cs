using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public interface IWonderVisualizer
    {
        string GetNameCard();
        Sprite GetBackground();
        Sprite GetCostFirstEra();
        Sprite GetCostSecondEra();
        Sprite GetCostThirdEra();
        Sprite GetInitialBonus();
        Sprite GetCurrentEffectStepTwo();
    }
}