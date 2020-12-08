using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbySender : MonoBehaviour
{
    
    public void GetLobbies()
    {
        LobbyManager.Instance.GetLobbyListRequest();
    }
}
