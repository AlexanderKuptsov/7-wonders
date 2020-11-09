using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;
using WhiteTeam.GameLogic;

public static class LobbyJsonCreator
{
    public enum LobbyType
    {
        connect,
        disconnect,
        create,
        delete,
        start
    }

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

    private class LobbyId
    {
        public string lobbyId { get; set; }
    }

    private class LobbyInfo
    {
        public string ownerId;
        public string ownerName;
        public string lobbyName;
        public string maxPlayers;
        public string moveTime;
    }
}