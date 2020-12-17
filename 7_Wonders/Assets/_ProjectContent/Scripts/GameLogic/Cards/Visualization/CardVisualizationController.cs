using System;
using UnityEngine;
using WhiteTeam.GameLogic.Cards.Wonder;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardVisualizationController : Singleton<CardVisualizationController>
    {
        [SerializeField] private GameObject cardVisualizer;

        [SerializeField] private GameObject cardHolder;
        /* TODO - prototypes
         
        [SerializeField] private GameObject RawMaterialsVisualizer;
        [SerializeField] private GameObject ManufactureVisualizer;
        [SerializeField] private GameObject CivilianVisualizer;
        [SerializeField] private GameObject ScientificVisualizer;
        [SerializeField] private GameObject CommercialMoneyVisualizer;
        [SerializeField] private GameObject CommercialTradeVisualizer;
        [SerializeField] private GameObject CommercialBonusVisualizer;
        [SerializeField] private GameObject MilitaryVisualizer;
        [SerializeField] private GameObject GuildsOwningVisualizer;
        [SerializeField] private GameObject GuildsScienceVisualizer;
        [SerializeField] private GameObject GuildsStrategyVisualizer;
        */

        public void Visualize(CommonCard card) // Common card visualization
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