using UnityEngine;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class WonderCardGameSetup : Singleton<WonderCardGameSetup>
    {
        [SerializeField] private WonderCardObjectVisualSetter cardObjectVisualSetter;

        public void Setup(WonderCard wonderCard)
        {
            var visualizer = wonderCard.Data.GetWonderVisualizer();

            var name = visualizer.GetNameCard();
            var background = visualizer.GetBackground();
            var costFirstEra = visualizer.GetCostFirstEra();
            var costSecondEra = visualizer.GetCostSecondEra();
            var costThirdEra = visualizer.GetCostThirdEra();

            var initialBonus = visualizer.GetInitialBonus();
            var stepTwoEffect = visualizer.GetCurrentEffectStepTwo();

            cardObjectVisualSetter.SetName(name);
            cardObjectVisualSetter.SetBackground(background);
            cardObjectVisualSetter.SetCostFirstEra(costFirstEra);
            cardObjectVisualSetter.SetCostSecondEra(costSecondEra);
            cardObjectVisualSetter.SetCostThirdEra(costThirdEra);
            cardObjectVisualSetter.SetInitialBonus(initialBonus);
            cardObjectVisualSetter.SetCurrentEffectStepTwo(stepTwoEffect);
        }
    }
}