using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.Network.ServerModules;

public static class LobbyJsonCreator
{


    private static string LobbyIdJson(LobbyType lobbyType, string lobbyId)
    {
        var lobbyIdJson = new LobbyId()
        {
            lobbyId = lobbyId
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(lobbyType.ToString(), jsonString));
    }

    private static string LobbyInfoJson(string ownerId, string ownerName, string lobbyName, int maxPlayers,
        int moveTime)
    {
        var lobbyInfoJson = new LobbyInfo()
        {
            ownerId = ownerId,
            ownerName = ownerName,
            lobbyName = lobbyName,
            maxPlayers = maxPlayers.ToString(),
            moveTime = moveTime.ToString()
        };
        var jsonString = JsonConvert.SerializeObject(lobbyInfoJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.create.ToString(), jsonString));
    }
    
    private static string UpdateLobbyInfoJson(string lobbyId, string playerId, string state)
    {
        var lobbyIdJson = new UpdateLobby()
        {
            lobbyId = lobbyId,
            playerId = playerId,
            state = state
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.update.ToString(), jsonString));
    }

    private static string DisconnectFromLobbyJson(string lobbyId, string playerId)
    {
        var lobbyIdJson = new PlayerIdLobby()
        {
            lobbyId = lobbyId,
            playerId = playerId,
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.disconnect.ToString(), jsonString));
    }
    
    private static string ConnectToLobbyJson(string lobbyId, string playerName)
    {
        var lobbyIdJson = new PlayerConnectLobby()
        {
            lobbyId = lobbyId,
            playerName = playerName,
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.connect.ToString(), jsonString));
    }

    public static string CreateConnectToLobbyJson(string lobbyId, string playerName)
    {
        return ConnectToLobbyJson(lobbyId, playerName);
    }
    

    public static string CreateDisconnectLobbyJson(string lobbyId, string playerId)
    {
        return DisconnectFromLobbyJson( lobbyId, playerId);
    }

    public static string CreateCreateLobbyJson(UserData userData, GameSettings gameSettings)
    {
        return LobbyInfoJson(userData.Id, userData.Name, gameSettings.Name, gameSettings.MaxPlayers,
            gameSettings.MoveTime);
    }

    public static string CreateDeleteLobbyJson(string lobbyId)
    {
        return LobbyIdJson(LobbyType.delete, lobbyId);
    }

    public static string CreateStartLobbyJson(string lobbyId)
    {
        return LobbyIdJson(LobbyType.start, lobbyId);
    }

    public static string CreateUpdateLobbyJson(string lobbyId, string playerId, string state)
    {
        return UpdateLobbyInfoJson(lobbyId, playerId, state);
    }

    private class LobbyId
    {
        public string lobbyId { get; set; }
    }

    private class LobbyInfo
    {
        public string ownerId { get; set; }
        public string ownerName { get; set; }
        public string lobbyName { get; set; }
        public string maxPlayers { get; set; }
        public string moveTime { get; set; }
    }

    private class PlayerIdLobby: LobbyId
    {
        public string playerId { get; set; }
    }

    private class UpdateLobby : PlayerIdLobby
    {
        public string state { get; set; }
    }

    private class PlayerConnectLobby : LobbyId
    {
        public string playerName { get; set; }
    }
}