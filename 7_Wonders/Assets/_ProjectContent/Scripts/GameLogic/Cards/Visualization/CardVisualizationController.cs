using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.ConnectingUI.Cards;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardVisualizationController : Singleton<CardVisualizationController>
    {
        [Header("Common cards")] [SerializeField]
        private GameObject cardVisualizer;

        [SerializeField] private CardsList inHandCardsList;

        public void AddInHandCards(IEnumerable<CommonCard> cards)
        {
            inHandCardsList.AddCards(cards);
        }

        public GameObject Visualize(CommonCard card, Transform cardHolder) // Common card visualization
        {
            var visualizer = card.Data.GetVisualizer();

            var cardName = visualizer.GetNameCard();
            var color = visualizer.GetColor();
            var cost = visualizer.GetCost();
            var background = visualizer.GetBackground();

            var currentEffect = visualizer.GetCurrentEffect();
            var endGameEffect = visualizer.GetEndGameEffect();


            var cardObject = Instantiate(cardVisualizer, cardHolder);
            var cardObjectVisualSetter = cardObject.GetComponent<CardObjectVisualSetter>();

            cardObjectVisualSetter.SetName(cardName);
            cardObjectVisualSetter.SetColor(color);
            cardObjectVisualSetter.SetCostEffect(cost);
            cardObjectVisualSetter.SetBackground(background);
            cardObjectVisualSetter.SetCurrentEffect(currentEffect);
            cardObjectVisualSetter.SetEndGameEffect(endGameEffect);

            return cardObject;
        }
    }
}