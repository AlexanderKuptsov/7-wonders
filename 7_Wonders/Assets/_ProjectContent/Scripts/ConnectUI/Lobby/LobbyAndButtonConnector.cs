using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbyAndButtonConnector : MonoBehaviour
{
    [SerializeField] private LobbyListElement lobbyListElement;
    [SerializeField] private CurrentLobbyDisplay playerListDisplay;

    [SerializeField] private Canvas canvasLobbyList;
    [SerializeField] private Canvas canvasLobby;

    public void GetIntoLobby()
    {
        
        if (!lobbyListElement.GetCurrentLobby().IsFull)
        {
            canvasLobby.gameObject.SetActive(true);
            canvasLobbyList.gameObject.SetActive(false);
            playerListDisplay.DisplayPlayers(lobbyListElement.GetCurrentLobby());
            playerListDisplay.SetCurrentLobby(lobbyListElement.GetCurrentLobby());
            FakeLobbyServer.Instance.FakeGetConnect(lobbyListElement.GetCurrentLobby(),
                LobbyManager.Instance.LocalUserData.Name);
        }
    }
}