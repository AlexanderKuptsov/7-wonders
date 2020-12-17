using System.Collections;
using System.Collections.Generic;
using Network.Json;
using UnityEngine;
using WhiteTeam.GameLogic;

public class LobbyJsonReceiver : JsonReceiverBase<LobbyResult, LobbyJsonReceiver>
{
    protected override LobbyResult OnErrorMsg(string msg)
    {
        return base.OnErrorMsg(msg);
    }
}

public class LobbyResult : Result
{
    public MainInfo results { get; set; }
}

public class MainInfo
{
    public CreationLobbyInfo lobbyInfo { get; set; }
    public LobbyInfo deleteInfo { get; set; }
    public LobbyInfo startCommandInfo { get; set; }
    public LobbyInfo disconnectInfo { get; set; }

    public LobbyInfo updateInfo { get; set; }

    public ConnectInfo connectInfo { get; set; }
    public CreationLobbyInfo[] lobbyList { get; set; }
}


public class LobbyInfo
{
    public string lobbyId { get; set; }

    public UserInfo[] connectedUsers { get; set; }
}
public class CreationLobbyInfo : LobbyInfo
{
    public string lobbyName { get; set; }
    public string maxPlayers { get; set; }
    public string moveTime { get; set; }
    public UserInfo ownerInfo { get; set; }
    public string accessToken { get; set; }
}

public class UserInfo
{
    public string playerName { get; set; }
    public string playerId { get; set; }
    public string state { get; set; }
}

public class ConnectInfo : LobbyInfo
{
    public string accessToken { get; set; }
}

