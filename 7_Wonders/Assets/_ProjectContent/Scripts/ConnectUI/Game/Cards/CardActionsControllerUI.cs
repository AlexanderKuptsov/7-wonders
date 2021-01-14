using System.Linq;
using UnityEngine;
using WhiteTeam.ConnectingUI.Cards;
using WhiteTeam.GameLogic.Cards;

public class CardActionsControllerUI : Singleton<CardActionsControllerUI>
{
    [SerializeField] private CardsList inHandCardsList;

    [SerializeField] private CardsList activatedCardsList;
    
    public void ActivateCard(CommonCard card)
    {
        activatedCardsList.AddCard(card);
    }

    public void RemoveLocalInHandCard(CommonCard card)
    {
        var cardElements = inHandCardsList.gameObject.GetComponentsInChildren<CardElement>();
        var targetCard = cardElements.Where(element => element.Card == card).ToArray();
        if (targetCard.Length > 0)
        {
            Destroy(targetCard[0].transform.parent.parent.gameObject);
        }
    }
}