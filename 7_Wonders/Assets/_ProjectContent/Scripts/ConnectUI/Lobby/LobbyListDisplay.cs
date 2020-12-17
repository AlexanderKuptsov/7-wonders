using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;

public class LobbyListDisplay : MonoBehaviour
{
    public GameObject lobbyListElement;
    public GameObject ScrollView;
    
    private void Start()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        //StartCoroutine(delayedDelete());
    }

    IEnumerator delayedCreate()
    {
        yield return new WaitForSeconds(10);
        LobbySender.Instance.CreateLobby();
    }
    
    IEnumerator delayedDelete()
    {
        yield return new WaitForSeconds(10);
        LobbySender.Instance.DeleteLobby();
    }
    void Awake()
    {
        LobbyManager.Instance.Events.OnUserConnectToLobby.Subscribe(UpdateLobbyListNoIdUI);
        LobbyManager.Instance.Events.OnUserDisconnectFromLobby.Subscribe(UpdateLobbyListNoIdUI);
        LobbyManager.Instance.Events.OnGetLobbyListToLobby.Subscribe(UpdateLobbyListUI);
        LobbyManager.Instance.Events.OnCreateLobby.Subscribe(ClearAndUpdate);
        LobbyManager.Instance.Events.OnDeleteLobby.Subscribe(ClearAndUpdate);
    }

    public void UpdateLobbyListUI()
    {
        Debug.Log("Updating UI");
        foreach (var lobby in LobbyManager.Instance._lobbies)
        {
            var newElement = Instantiate(lobbyListElement, ScrollView.transform);
            var infoFields = newElement.GetComponent<LobbyListElement>();
            infoFields.SetName(lobby.Settings.Name);
            infoFields.SetPlayers(lobby.ConnectedUsersCount, lobby.Settings.MaxPlayers);
            infoFields.SetMoveTime(lobby.Settings.MoveTime);
            infoFields.SetCurrentLobby(lobby);
        }
    }

    public void UpdateLobbyListNoIdUI(string lobbyId) //TODO ??????
    {
        UpdateLobbyListUI();
    }

    public void ClearElements()
    {
        LobbyManager.Instance._lobbies.Clear();
        ClearLobbyListUI();
    }

    public void ClearLobbyListUI()
    {
        foreach (var element in ScrollView.GetComponentsInChildren<LobbyListElement>())
        {
            Destroy(element.transform.gameObject);
        }
    }

    public void RefreshLobbies()
    {
        ClearElements();
        LobbySender.Instance.GetLobbies();
    }

    public void ClearAndUpdate()
    {
        ClearLobbyListUI();
        UpdateLobbyListUI();
    }
}