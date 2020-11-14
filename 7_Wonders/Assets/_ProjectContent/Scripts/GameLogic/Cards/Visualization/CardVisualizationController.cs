using System;
using UnityEngine;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardVisualizationController : Singleton<CardVisualizationController>
    {
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

        public void AddVisualizer(Card card)
        {
            GameObject visualizer;
            switch (card.Data.Type)
            {
                case CardType.RAW_MATERIALS:
                    visualizer = RawMaterialsVisualizer;
                    break;
                case CardType.MANUFACTURE:
                    visualizer = ManufactureVisualizer;
                    break;
                case CardType.CIVILIAN:
                    visualizer = CivilianVisualizer;
                    break;
                case CardType.SCIENTIFIC:
                    visualizer = ScientificVisualizer;
                    break;
                case CardType.COMMERCIAL:
                    switch (((CommercialCard) card.Data).CommercialType)
                    {
                        case CommercialCard.CommercialInfo.MONEY:
                            visualizer = CommercialMoneyVisualizer;
                            break;
                        case CommercialCard.CommercialInfo.TRADE:
                            visualizer = CommercialTradeVisualizer;
                            break;
                        case CommercialCard.CommercialInfo.BONUS:
                            visualizer = CommercialBonusVisualizer;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                case CardType.MILITARY:
                    visualizer = MilitaryVisualizer;
                    break;
                case CardType.GUILDS:
                    switch (((GuildsCard) card.Data).GuildsType)
                    {
                        case GuildsCard.GuildsInfo.OWNING:
                            visualizer = GuildsOwningVisualizer;
                            break;
                        case GuildsCard.GuildsInfo.STRATEGY:
                            visualizer = GuildsStrategyVisualizer;
                            break;
                        case GuildsCard.GuildsInfo.SCIENCE:
                            visualizer = GuildsScienceVisualizer;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            AddToCard(card, visualizer);
        }

        private static void AddToCard(Card card, GameObject visualizer)
        {
            Instantiate(visualizer, card.transform);
        }
    }
}