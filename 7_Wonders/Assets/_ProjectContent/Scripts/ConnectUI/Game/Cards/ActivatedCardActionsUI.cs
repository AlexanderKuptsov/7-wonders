using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.ConnectingUI.Cards;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;

public class ActivatedCardActionsUI : MonoBehaviour
{
    [SerializeField] private CardElement cardElement;
        
    [SerializeField] private GameObject actionsHolder;

    private PlayerData localPlayer => GameManager.Instance.CurrentSession.LocalPlayerData;
    
    // public void Show()
    // {
    //     actionsHolder.SetActive(true);
    // }
    //
    // public void Close()
    // {
    //     actionsHolder.SetActive(false);
    // }

    public void Use()
    {
        cardElement.Card.ActivatedUse(localPlayer);
    }
}
