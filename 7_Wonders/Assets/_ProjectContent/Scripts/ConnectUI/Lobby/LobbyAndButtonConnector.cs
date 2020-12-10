using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyAndButtonConnector : MonoBehaviour
{
    [SerializeField] private LobbyListElement lobbyListElement;
    [SerializeField] private CurrentLobbyDisplay playerListDisplay;

    public void GetIntoLobby()
    {
        playerListDisplay.DisplayPlayers(lobbyListElement.GetCurrentLobby());
    }
}
