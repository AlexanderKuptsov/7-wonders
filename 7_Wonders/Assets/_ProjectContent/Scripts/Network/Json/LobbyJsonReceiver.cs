using System.Collections;
using System.Collections.Generic;
using Network.Json;
using UnityEngine;

public class LobbyJsonReceiver : JsonReceiverBase<LobbyResult, LobbyJsonReceiver>
{
}

    public class LobbyResult : Result
    {
        public MainInfo results { get; set; }
    }

    public class MainInfo
    {
        public string lobbyId { get; set; }
        public string playerId { get; set; }
        public OwnerInfo ownerInfo { get; set; }
        public LobbyInfo lobbyInfo { get; set; }
        
        public UpdateInfo updateInfo { get; set; }
        
        public ConnectInfo connectInfo { get; set; }
    }

    public class OwnerInfo
    {
        public string ownerId { get; set; }
        public string ownerName { get; set; }
    }

    public class LobbyInfo
    {
        public string lobbyName { get; set; }
        public string maxPlayers { get; set; }
        public string moveTime { get; set; }
    }

    public class UpdateInfo
    {
        public string state { get; set; }
    }

    public class ConnectInfo
    {
        public string playerName { get; set; }
    }
