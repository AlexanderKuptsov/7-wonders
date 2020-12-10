using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;

public class PlayerListElement : MonoBehaviour
{
    [SerializeField] private TMP_Text playerIdText;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private PlayerState playerReadyState;

    public void SetId(string id)
    {
        playerIdText.text = id;
    }
    
    public void setName(string name)
    {
        playerNameText.text = name;
    }
    
    public void setReadyState(UserData.ReadyState readyState)
    {
        if (readyState == UserData.ReadyState.READY)
        {
            playerReadyState.setReadyState();
        }
        else
        {
            playerReadyState.setNotReadyState();
        }
    }
}
