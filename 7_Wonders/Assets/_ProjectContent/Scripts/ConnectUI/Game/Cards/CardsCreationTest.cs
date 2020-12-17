using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

public class CardsCreationTest : MonoBehaviour
{
    private void Start()
    {
        // Data from server
        var cardData = new RawMaterialsCard(
            "23",
            "RawMaterialCard",
            CommonCardData.CardType.PRODUCTION,
            1,
            new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 1}
            },
            "",
            new ProductionCardEffect(new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.WOOD, Amount = 2},
            }));

        // logic card creation
        var card = CardCreator.Create(cardData);

        // card visualisation
        CardVisualizationController.Instance.Visualize(card);
    }
}