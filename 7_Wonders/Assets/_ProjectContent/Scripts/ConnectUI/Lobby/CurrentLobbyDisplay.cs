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
}
