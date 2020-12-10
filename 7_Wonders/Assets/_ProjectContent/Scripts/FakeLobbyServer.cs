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
        var createMessage = "{\"status\":\"SUCCESS\",\"results\":{\"lobbyId\": \"2\", \"ownerInfo\": {\"ownerId\":\"1\", \"ownerName\": \"Aleksei\"},\"lobbyInfo\": {\"lobbyName\":\"newLobby\",\"maxPlayers\":\"5\",\"moveTime\":\"60\"}},\"module\":\"Lobby\",\"type\":\"create\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(createMessage);
    }
}
