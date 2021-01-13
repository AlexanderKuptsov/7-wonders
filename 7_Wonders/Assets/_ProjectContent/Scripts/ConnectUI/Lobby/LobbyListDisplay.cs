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
    IEnumerator _createLobbiesCoroutine;
    IEnumerator _deleteLobbiesCoroutine;
    private bool _serverIsOn = false;
    
    private void Start()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        _createLobbiesCoroutine = fakeCreate();
        _deleteLobbiesCoroutine = fakeDelete();
    }

    public void FakeServerStopStart()
    {
        if (_serverIsOn)
        {
            StopCoroutine(_createLobbiesCoroutine);
            StopCoroutine(_deleteLobbiesCoroutine);
        }
        else
        {
            StartCoroutine(_createLobbiesCoroutine);
            StartCoroutine(_deleteLobbiesCoroutine);
        }
        _serverIsOn = !_serverIsOn;
    }
    IEnumerator fakeCreate()
    {
        for (;;)
        {
            LobbySender.Instance.CreateRandomLobby();
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator fakeDelete()
    {
        for (;;)
        {
            yield return new WaitForSeconds(7);
            LobbySender.Instance.DeleteRandomLobby();
        }
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

    public void GetRandomLobby()
    {
        LobbySender.Instance.CreateRandomLobby();
        ClearAndUpdate();
    }

    public void DeleteRandomLobby()
    {
        LobbySender.Instance.DeleteRandomLobby();
        ClearAndUpdate();
    }

    public void ClearAndUpdate()
    {
        ClearLobbyListUI();
        UpdateLobbyListUI();
    }
}