using UnityEngine;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class WonderCardGameSetup : Singleton<WonderCardGameSetup>
    {
        [SerializeField] private WonderCardObjectVisualSetter cardObjectVisualSetter;
        [SerializeField] private GameObject firstWonderBuiltPanel;
        [SerializeField] private GameObject secondWonderBuiltPanel;
        [SerializeField] private GameObject thirdWonderBuiltPanel;
        private int wonderStepCounter = 0;

        public void GlobalSetup(WonderCard wonderCard)
        {
            Setup(wonderCard, cardObjectVisualSetter);
        }

        public void Setup(WonderCard wonderCard, WonderCardObjectVisualSetter cardSetter)
        {
            var visualizer = wonderCard.Data.GetWonderVisualizer();

            var name = visualizer.GetNameCard();
            var background = visualizer.GetBackground();
            var costFirstEra = visualizer.GetCostFirstEra();
            var costSecondEra = visualizer.GetCostSecondEra();
            var costThirdEra = visualizer.GetCostThirdEra();

            var initialBonus = visualizer.GetInitialBonus();
            var stepTwoEffect = visualizer.GetCurrentEffectStepTwo();

            cardSetter.SetName(name);
            cardSetter.SetBackground(background);
            cardSetter.SetCostFirstEra(costFirstEra);
            cardSetter.SetCostSecondEra(costSecondEra);
            cardSetter.SetCostThirdEra(costThirdEra);
            cardSetter.SetInitialBonus(initialBonus);
            cardSetter.SetCurrentEffectStepTwo(stepTwoEffect);
        }

        public void WonderBuild()
        {
            switch (wonderStepCounter)
            {
                case 0:
                    firstWonderBuiltPanel.gameObject.SetActive(true);
                    break;
                case 1:
                    secondWonderBuiltPanel.gameObject.SetActive(true);
                    break;
                case 2:
                    thirdWonderBuiltPanel.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
            wonderStepCounter += 1;
        }
    }
}