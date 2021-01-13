using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardVisualizationController : Singleton<CardVisualizationController>
    {
        [Header("Common cards")]
        [SerializeField] private GameObject cardVisualizer;
        [SerializeField] private GameObject cardHolder;
        
        [Header("Wonder cards")]
        [SerializeField] private GameObject wonderCardVisualizer;
        [SerializeField] private GameObject wonderCardHolder;

        public GameObject Visualize(CommonCard card) // Common card visualization
        {
            var visualizer = card.Data.GetVisualizer();

            var cardName = visualizer.GetNameCard();
            var color = visualizer.GetColor();
            var cost = visualizer.GetCost();
            var background = visualizer.GetBackground();

            var currentEffect = visualizer.GetCurrentEffect();
            var endGameEffect = visualizer.GetEndGameEffect();


            var cardObject = Instantiate(cardVisualizer, cardHolder.transform);
            var cardObjectVisualSetter = cardObject.GetComponent<CardObjectVisualSetter>();

            cardObjectVisualSetter.SetName(cardName);
            cardObjectVisualSetter.SetColor(color);
            cardObjectVisualSetter.SetCostEffect(cost);
            cardObjectVisualSetter.SetBackground(background);
            cardObjectVisualSetter.SetCurrentEffect(currentEffect);
            cardObjectVisualSetter.SetEndGameEffect(endGameEffect);

            return cardObject;
        }

        public GameObject Visualize(WonderCard card) // Wonder card visualization
        {
            var visualizer = card.Data.GetWonderVisualizer();

            var name = visualizer.GetNameCard();
            var background = visualizer.GetBackground();
            var costFirstEra = visualizer.GetCostFirstEra();
            var costSecondEra = visualizer.GetCostSecondEra();
            var costThirdEra = visualizer.GetCostThirdEra();

            var initialBonus = visualizer.GetInitialBonus();
            var stepTwoEffect = visualizer.GetCurrentEffectStepTwo();

            var cardObject = Instantiate(wonderCardVisualizer, cardHolder.transform);
            var cardObjectVisualSetter = cardObject.GetComponent<WonderCardObjectVisualSetter>();

            cardObjectVisualSetter.SetName(name);
            cardObjectVisualSetter.SetBackground(background);
            cardObjectVisualSetter.SetCostFirstEra(costFirstEra);
            cardObjectVisualSetter.SetCostSecondEra(costSecondEra);
            cardObjectVisualSetter.SetCostThirdEra(costThirdEra);
            cardObjectVisualSetter.SetInitialBonus(initialBonus);
            cardObjectVisualSetter.SetCurrentEffectStepTwo(stepTwoEffect);

            return cardObject;
        }
    }
}