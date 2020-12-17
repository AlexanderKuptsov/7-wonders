using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;

public class CurrentLobbyDisplay : MonoBehaviour
{
    public GameObject playerListElement;
    public TMP_Text playersCountText;
    public TMP_Text moveTimeText;
    public GameObject ScrollView;
    private Lobby currentLobby;


    private void Awake()
    {
        LobbyManager.Instance.Events.OnUpdateLobbies.Subscribe(OnLobbyUpdate);
        LobbyManager.Instance.Events.OnUserConnectToLobby.Subscribe(OnLobbyUpdate);
        LobbyManager.Instance.Events.OnUserDisconnectFromLobby.Subscribe(OnLobbyUpdate);
        
    }

    public void DisplayPlayers(Lobby lobby)
    {
        foreach (var user in lobby.ConnectedUsers)
        {
            var newElement = Instantiate(playerListElement, ScrollView.transform);
            var infoFields = newElement.GetComponent<PlayerListElement>();
            infoFields.SetId(user.Id);
            infoFields.setName(user.Name);
            Debug.Log(user.state);
            infoFields.setReadyState(user.state);
        }
        playersCountText.text = lobby.ConnectedUsersCount.ToString();
        moveTimeText.text = lobby.Settings.MoveTime.ToString();
    }
    
    public void ClearElements()
    {
        foreach (var element in ScrollView.GetComponentsInChildren<PlayerListElement>())
        {
            Destroy(element.transform.gameObject);
        }
    }

    public void OnLobbyUpdate(string lobbyId)
    {
        if (lobbyId == currentLobby.Id)
        {
            ClearElements();
            DisplayPlayers(currentLobby);
        }
    }

    public void SetCurrentLobby(Lobby currentLobby)
    {
        this.currentLobby = currentLobby;
    }
}
