using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.Network.ServerModules;

public static class LobbyJsonCreator
{


    private static string CreateLobbyIdJson(LobbyType lobbyType, string lobbyId)
    {
        var lobbyIdJson = new LobbyId()
        {
            lobbyId = lobbyId
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(lobbyType.ToString(), jsonString));
    }

    private static string CreateLobbyInfoJson(string ownerId, string ownerName, string lobbyName, int maxPlayers,
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
    
    private static string CreateUpdateLobbyInfoJson(string lobbyId, string playerId, string state)
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

    public static string CreateConnectToLobbyJson(string lobbyId)
    {
        return CreateLobbyIdJson(LobbyType.connect, lobbyId);
    }

    public static string CreateDisconnectLobbyJson(string lobbyId)
    {
        return CreateLobbyIdJson(LobbyType.disconnect, lobbyId);
    }

    public static string CreateCreateLobbyJson(UserData userData, GameSettings gameSettings)
    {
        return CreateLobbyInfoJson(userData.Id, userData.Name, gameSettings.Name, gameSettings.MaxPlayers,
            gameSettings.MoveTime);
    }

    public static string CreateDeleteLobbyJson(string lobbyId)
    {
        return CreateLobbyIdJson(LobbyType.delete, lobbyId);
    }

    public static string CreateStartLobbyJson(string lobbyId)
    {
        return CreateLobbyIdJson(LobbyType.start, lobbyId);
    }

    public static string CreateUpdateLobbyJson(string lobbyId, string playerId, string state)
    {
        return CreateUpdateLobbyInfoJson(lobbyId, playerId, state);
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

    private class UpdateLobby: LobbyId
    {
        public string playerId { get; set; }
        public string state { get; set; }
    }
}