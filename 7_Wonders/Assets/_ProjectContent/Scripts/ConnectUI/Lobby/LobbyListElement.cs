using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic.Managers;

public class LobbyListElement : MonoBehaviour
{
    [SerializeField] private TMP_Text lobbyNameText;
    [SerializeField] private TMP_Text maxPlayersText;
    [SerializeField] private TMP_Text moveTimeText;
    private Lobby elementLobby;

    public void SetName(string lobbyName)
    {
        lobbyNameText.text = lobbyName;
    }
    
    public void SetPlayers(int currentPlayers, int maxPlayers)
    {
        maxPlayersText.text = $"{currentPlayers}/{maxPlayers}";
    }
    
    public void SetMoveTime(int moveTime)
    {
        moveTimeText.text = moveTime.ToString();
    }

    public Lobby GetCurrentLobby()
    {
        return elementLobby;
    }

    public void SetCurrentLobby(Lobby lobby)
    {
        elementLobby = lobby;
    }
}
