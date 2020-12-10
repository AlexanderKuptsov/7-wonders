using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbyListDisplay : MonoBehaviour
{
    public GameObject lobbyListElement;
    public GameObject ScrollView;
    void Awake()
    {
        LobbyManager.Instance.Events.OnGetLobbyListToLobby.Subscribe(UpdateLobbyListUI);
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

    public void ClearElements()
    {
        LobbyManager.Instance._lobbies.Clear();
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
}
