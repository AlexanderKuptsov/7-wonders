using UnityEngine;
using WhiteTeam.ConnectingUI.Cards;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;

public class CardsCreationTest : MonoBehaviour
{
    [SerializeField] private WonderCardObjectVisualSetter cardObjectVisualSetter;
    
    private void Start()
    {
        CreateCommonCard();
        CreateWonderCard();
    }

    private void CreateCommonCard()
    {
        // Data from server
        var cardData1 = new ScientificCard(
            "423",
            "Science",
            CommonCardData.CardType.COMMERCIAL_TRADE,
            1,
            new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
            },
            "",
            new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1}));

        //logic card creation
        var card1 = CardCreator.Create(cardData1);

        var cardData2 = new MilitaryCard(
            "213",
            "Military",
            CommonCardData.CardType.MILITARY,
            1,
            new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.STONE, Amount = 1}
            },
            "",
            new MilitaryEffect(2));

        //logic card creation
        var card2 = CardCreator.Create(cardData2);

        var cardData3 = new ProductionCard(
            "223",
            "Production",
            CommonCardData.CardType.PRODUCTION,
            1,
            null,
            "",
            new ProductionCardEffect(new[]
                {new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.PAPYRUS, Amount = 1},}));

        //logic card creation
        var card3 = CardCreator.Create(cardData3);


        //GLASS 1 PAPYRUS 1 LOOM 1 WOOD 1 ORE 1 STONE 1   glass_papyrus_loom_brick_wood_ore_stone

        var cardData4 = new CommercialMoneyCard(
            "223",
            "Trade",
            CommonCardData.CardType.COMMERCIAL_MONEY,
            1,
            new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.GLASS, Amount = 1},
            },
            "",
            new MoneyEffect(5));

        //logic card creation
        var card4 = CardCreator.Create(cardData4);

        // card visualisation
        //CardVisualizationController.Instance.Visualize(card, transform);

        CardVisualizationController.Instance.AddInHandCards(new[] {card1, card2, card3, card4, card1, card2, card3});
    }

    private void CreateWonderCard()
    {
        // Data from server
        var wonderCardData = WonderCardsBuilder.CreateHangingGardens("1234");
        //logic card creation
        var wonderCard = CardCreator.Create(wonderCardData);

        // card visualisation
        //CardVisualizationController.Instance.Visualize(wonderCard);

        WonderCardGameSetup.Instance.GlobalSetup(wonderCard);
    }
}