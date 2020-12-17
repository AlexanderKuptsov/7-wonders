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

    private static string LobbyInfoJson( string ownerName, string lobbyName, int maxPlayers,
        int moveTime, string accessToken)
    {
        var lobbyInfoJson = new LobbyInfo()
        {
            ownerName = ownerName,
            lobbyName = lobbyName,
            maxPlayers = maxPlayers.ToString(),
            moveTime = moveTime.ToString(),
            accessToken = accessToken
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
    
    private static string ConnectToLobbyJson(string lobbyId, string playerName, string sessionId)
    {
        var lobbyIdJson = new PlayerConnectLobby()
        {
            lobbyId = lobbyId,
            playerName = playerName,
            accessToken = sessionId
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.connect.ToString(), jsonString));
    }

    public static string GetLobbyListJson()
    {
        var jsonString = JsonConvert.SerializeObject(new NoAttributes());
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(LobbyType.getLobby.ToString(), jsonString));
    }
    public static string CreateConnectToLobbyJson(string lobbyId, string playerName, string sessionId)
    {
        return ConnectToLobbyJson(lobbyId, playerName, sessionId);
    }
    

    public static string CreateDisconnectLobbyJson(string lobbyId, string playerId)
    {
        return DisconnectFromLobbyJson( lobbyId, playerId);
    }

    public static string CreateCreateLobbyJson(string playerName, GameSettings gameSettings, string accessToken)
    {
        return LobbyInfoJson( playerName, gameSettings.Name, gameSettings.MaxPlayers,
            gameSettings.MoveTime, accessToken);
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

    private class NoAttributes
    {
        
    }
    private class LobbyId
    {
        public string lobbyId { get; set; }
    }

    private class LobbyInfo
    {
        public string ownerName { get; set; }
        public string lobbyName { get; set; }
        public string maxPlayers { get; set; }
        public string moveTime { get; set; }
        
        public string accessToken { get; set; }
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
        public string accessToken { get; set; }
    }
}