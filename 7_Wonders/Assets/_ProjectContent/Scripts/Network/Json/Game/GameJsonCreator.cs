using System.Collections;
using System.Collections.Generic;
using Network.Json;
using Newtonsoft.Json;
using UnityEngine;
using WhiteTeam.Network.ServerModules;

public static class GameJsonCreator
{
    private static string LobbyIdJson(GameMessageType gameMessageType, string lobbyId)
    {
        var lobbyIdJson = new LobbyId()
        {
            lobbyId = lobbyId
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(gameMessageType.ToString(), jsonString));
    }
    
    private static string GameIdJson(GameMessageType gameMessageType, string lobbyId)
    {
        var lobbyIdJson = new LobbyId()
        {
            lobbyId = lobbyId
        };
        var jsonString = JsonConvert.SerializeObject(lobbyIdJson);
        return JsonCreator.RemoveSlash(JsonCreator.CreateJson(gameMessageType.ToString(), jsonString));
    }
    
    public static string CreateInitJson(string lobbyId)
    {
        return LobbyIdJson(GameMessageType.init, lobbyId);
    }
    
    public static string CreateStartJson(string gameId)
    {
        return LobbyIdJson(GameMessageType.start, gameId);
    }
    
    public static string CreateNextMoveJson(string gameId)
    {
        return GameIdJson(GameMessageType.move, gameId);
    }
    
    public static string CreateNextEpochJson(string gameId)
    {
        return GameIdJson(GameMessageType.newEpoch, gameId);
    }
    
    public static string CreateEndGameJson(string gameId)
    {
        return GameIdJson(GameMessageType.endGameScore, gameId);
    }

    public static string CardActionJson(string gameId, string cardId, string command)
    {
        return CardsJsonCreator.CreateCardJson(gameId, cardId, command);
    }
    
    private class LobbyId
    {
        public string lobbyId { get; set; }
    }
    
    private class GameId
    {
        public string gameId { get; set; }
    }
    
    
}
