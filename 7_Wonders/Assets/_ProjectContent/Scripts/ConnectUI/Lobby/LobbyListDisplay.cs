using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbyListDisplay : MonoBehaviour
{
    public GameObject lobbyListElement;
    public GameObject ScrollView;
    void Start()
    {
        LobbyManager.Instance.Events.OnGetLobbyListToLobby.Subscribe(UpdateLobbyListUI);
    }

    public void UpdateLobbyListUI()
    {
        foreach (var lobby in LobbyManager.Instance._lobbies)
        {
            var newElement = Instantiate(lobbyListElement, ScrollView.transform);
            var infoFields = newElement.GetComponent<LobbyListElement>();
            infoFields.SetName(lobby.GetFullName());
            infoFields.setPlayers(lobby.ConnectedUsersCount, lobby.Settings.MaxPlayers);
            infoFields.setMoveTime(lobby.Settings.MoveTime);
        }
       
    }

    public void ClearElements()
    {
        LobbyManager.Instance._lobbies.Clear();
        LobbyManager.Instance.GetLobbyListRequest();
        foreach (var element in ScrollView.GetComponentsInChildren<LobbyListElement>())
        {
            Destroy(element.transform.gameObject);
        }
    }
}
