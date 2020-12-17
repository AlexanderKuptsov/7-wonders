using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.Network.ServerModules;

public class FakeLobbyServer : Singleton<FakeLobbyServer>
{
    public void FakeGetLobbiesAnswer()
    {
        var lobbyListMessage =
            "{\"status\": \"SUCCESS\",\"results\": {\"lobbyList\":[{\"lobbyId\": \"1\",\"lobbyName\":\"Game 1\", \"maxPlayers\": \"7\", \"moveTime\": \"30\", \"ownerInfo\": {\"playerName\": \"creator\", \"playerId\": \"1\", \"state\": \"READY\"}, \"connectedUsers\": [{\"playerName\": \"player1\", \"playerId\": \"2\", \"state\": \"WAITING\"},{\"playerName\": \"player2\", \"playerId\": \"3\", \"state\": \"WAITING\"}]},{\"lobbyId\": \"2\",\"lobbyName\":\"Game 2\", \"maxPlayers\": \"6\", \"moveTime\": \"45\", \"ownerInfo\": {\"playerName\": \"creator\", \"playerId\": \"1\", \"state\": \"WAITING\"}, \"connectedUsers\": [{\"playerName\": \"player1\", \"playerId\": \"2\", \"state\": \"WAITING\"},{\"playerName\": \"player2\", \"playerId\": \"3\", \"state\": \"WAITING\"}]}]},\"module\":\"Lobby\",\"type\":\"getLobby\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(lobbyListMessage);
    }

    public void FakeCreateAnswer()
    {
        var createMessage =
            "{\"status\": \"SUCCESS\",\"results\": {\"lobbyInfo\":{\"lobbyId\": \"3\",\"lobbyName\":\"BestGame\", \"maxPlayers\": \"6\", \"moveTime\": \"45\", \"ownerInfo\": {\"playerName\": \"Aleksei\", \"playerId\": \"1\", \"state\": \"WAITING\"}, \"connectedUsers\": [], \"accessToken\": \"asdasdasdasd123123123\"}}, \"module\":\"Lobby\",\"type\":\"create\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(createMessage);
    }

    public void FakeDeleteAnswer()
    {
        var deleteMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"deleteInfo\": {\"lobbyId\": \"1\"}},\"module\":\"Lobby\",\"type\":\"delete\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(deleteMessage);
    }


    public void FakeConnectAnswer()
    {
        var connectMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"connectInfo\": {\"lobbyId\": \"1\", \"connectedUsers\": [{\"playerId\":\"2\", \"playerName\": \"Aleksei\"}]}, \"accessToken\": \"asdasdasd123123123\"},\"module\":\"Lobby\",\"type\":\"connect\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(connectMessage);
    }

    public void FakeDisconnectAnswer()
    {
        var disconnectMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"disconnectInfo\": {\"lobbyId\": \"2\", \"connectedUsers\": [{\"playerId\":\"2\"}]}},\"module\":\"Lobby\",\"type\":\"disconnect\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(disconnectMessage);
    }


    public void FakeUpdateLobbyAnswer()
    {
        var updateMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"updateInfo\": {\"lobbyId\": \"2\", \"connectedUsers\": [{\"playerId\":\"2\", \"state\": \"READY\"}]}},\"module\":\"Lobby\",\"type\":\"update\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(updateMessage);
    }
    
    public void FakeStartLobbyAnswer()
    {
        var startMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"startInfo\": {\"lobbyId\": \"1\"}},\"module\":\"Lobby\",\"type\":\"start\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(startMessage);
    }
}