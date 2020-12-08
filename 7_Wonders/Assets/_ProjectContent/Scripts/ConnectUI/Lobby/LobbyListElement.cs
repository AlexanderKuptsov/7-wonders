using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyListElement : MonoBehaviour
{
    [SerializeField] private TextMeshPro lobbyNameText;
    [SerializeField] private TextMeshPro maxPlayersText;
    [SerializeField] private TextMeshPro moveTimeText;

    public void SetName(string lobbyName)
    {
        lobbyNameText.text = lobbyName;
    }
    
    public void setPlayers(int currentPlayers, int maxPlayers)
    {
        maxPlayersText.text = $"{currentPlayers}/{maxPlayers}";
    }
    
    public void setMoveTime(int moveTime)
    {
        moveTimeText.text = moveTime.ToString();
    }
}
