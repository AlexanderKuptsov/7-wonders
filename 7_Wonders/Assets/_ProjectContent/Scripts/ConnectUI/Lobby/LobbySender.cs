using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbySender : Singleton<LobbySender>
{

    public void GetLobbies()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeGetLobbiesAnswer();
    }
    
    public void CreateRandomLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.CreateRandomLobby();
    }
    
    public void DeleteRandomLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        
        FakeLobbyServer.Instance.DeleteRandomLobby();
    }
    
    public void CreateLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeCreateAnswer();
    }
    
    public void DeleteLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeDeleteAnswer();
    }
    
    public void ConnectToLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeConnectAnswer();
    }
    
    public void DisconnectFromLobby()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeDisconnectAnswer();
    }
    
    public void UpdateUserState()
    {
        //LobbyManager.Instance.GetLobbyListRequest();
        FakeLobbyServer.Instance.FakeUpdateLobbyAnswer();
    }
}
