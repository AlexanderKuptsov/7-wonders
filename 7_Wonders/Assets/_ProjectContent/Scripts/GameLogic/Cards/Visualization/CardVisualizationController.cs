using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardVisualizationController : Singleton<CardVisualizationController>
    {
        [SerializeField] private GameObject cardVisualizer;

        [SerializeField] private GameObject cardHolder;

        public GameObject Visualize(CommonCard card) // Common card visualization
        {
            var visualizer = card.Data.GetVisualizer();

            // Example
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

        public void Visualize(WonderCard card) // Wonder card visualization
        {
            var visualizer = card.Data.GetVisualizer();

            /* TODO
            
            GetName
            GetCost
            GetColor
            GetEffect
            ...
            
            */
        }
    }
}