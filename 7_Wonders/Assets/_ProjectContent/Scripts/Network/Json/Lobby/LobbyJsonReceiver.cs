using System.Collections;
using System.Collections.Generic;
using Network.Json;
using UnityEngine;

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
    public LobbyInfo lobbyInfo { get; set; }
    public DeleteInfo deleteInfo { get; set; }
    public StartCommandInfo startCommandInfo { get; set; }
    public DisconnectInfo disconnectInfo { get; set; }

    public UpdateInfo updateInfo { get; set; }

    public ConnectInfo connectInfo { get; set; }
    public LobbyListInfo[] lobbyList { get; set; }
}


public class LobbyInfo
{
    public string lobbyId { get; set; }
    public string lobbyName { get; set; }
    public string maxPlayers { get; set; }
    public string moveTime { get; set; }
    public string ownerId { get; set; }
    public string ownerName { get; set; }
}

public class PlayerAndLobbyId
{
    public string playerId { get; set; }
    public string lobbyId { get; set; }
}


public class StartCommandInfo
{
    public string lobbyId { get; set; }
}


public class UpdateInfo : PlayerAndLobbyId
{
    public string state { get; set; }
}

public class DeleteInfo
{
    public string lobbyId { get; set; }
}

public class DisconnectInfo : PlayerAndLobbyId
{
}

public class ConnectInfo : PlayerAndLobbyId
{
    public string playerName { get; set; }
}

public class LobbyListInfo : LobbyInfo
{
    LobbyInfo lobbyInfo { get; set; }
}
