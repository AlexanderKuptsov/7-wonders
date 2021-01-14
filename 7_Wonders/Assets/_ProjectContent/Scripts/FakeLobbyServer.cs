using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.ServerModules;
using Random = System.Random;

public class FakeLobbyServer : Singleton<FakeLobbyServer>
{
    private int lastLobbyId = 3;
    private static Random random = new Random();
    private List<int> availableLobbies = new List<int>();
    
    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public void FakeGetLobbiesAnswer()
    {
        var lobbyListMessage =
            "{\"status\": \"SUCCESS\",\"results\": {\"lobbyList\":[{\"lobbyId\": \"1\",\"lobbyName\":\"Game 1\", \"maxPlayers\": \"7\", \"moveTime\": \"30\", \"ownerInfo\": {\"playerName\": \"creator\", \"playerId\": \"1\", \"state\": \"READY\"}, \"connectedUsers\": [{\"playerName\": \"player1\", \"playerId\": \"2\", \"state\": \"WAITING\"},{\"playerName\": \"player2\", \"playerId\": \"3\", \"state\": \"WAITING\"}]},{\"lobbyId\": \"2\",\"lobbyName\":\"Game to start\", \"maxPlayers\": \"4\", \"moveTime\": \"45\", \"ownerInfo\": {\"playerName\": \"admin\", \"playerId\": \"1\", \"state\": \"READY\"}, \"connectedUsers\": [{\"playerName\": \"player1\", \"playerId\": \"2\", \"state\": \"READY\"},{\"playerName\": \"player2\", \"playerId\": \"3\", \"state\": \"READY\"}]}]},\"module\":\"Lobby\",\"type\":\"getLobby\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(lobbyListMessage);
    }
    
    public void CreateRandomLobby()
    {
        var rndName = RandomString(4);
        var rndMaxPlayers = random.Next(3, 7);
        var rndCreatorName = RandomString(random.Next(3, 7));
        var createMessage =
            "{\"status\": \"SUCCESS\",\"results\": {\"lobbyInfo\":{\"lobbyId\": \""+ lastLobbyId +"\",\"lobbyName\":\""+ rndName +"\", \"maxPlayers\": \""+ rndMaxPlayers +"\", \"moveTime\": \"45\", \"ownerInfo\": {\"playerName\": \""+ rndCreatorName +"\", \"playerId\": \"1\", \"state\": \"WAITING\"}, \"connectedUsers\": [], \"accessToken\": \"asdasdasdasd123123123\"}}, \"module\":\"Lobby\",\"type\":\"create\"}";
        lastLobbyId += 1;
        availableLobbies.Add(lastLobbyId);
        ServerLobbyHandler.Instance.FakeOnMessageReceived(createMessage);
    }

    public void DeleteRandomLobby()
    {
        var index = random.Next(0, availableLobbies.Count);
        Debug.Log($"DELETING LOBBY A; INDEX: {index} AND COUNT: {availableLobbies.Count}");
        if (availableLobbies.Count > 0)
        {
            Debug.Log("DELETING LOBBY");
            var lobbyId = availableLobbies[index];
            var deleteMessage = 
                "{\"status\":\"SUCCESS\",\"results\":{\"deleteInfo\": {\"lobbyId\": \"" + lobbyId + "\"}},\"module\":\"Lobby\",\"type\":\"delete\"}";
            ServerLobbyHandler.Instance.FakeOnMessageReceived(deleteMessage);
            availableLobbies.Remove(index);
        }
    }

    public void FakeGetConnect(Lobby lobby, string ourName)
    {
        var nextIndex = lobby.ConnectedUsersCount + 1;
        var lobbyId = lobby.Id;
        var connectMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"connectInfo\": {\"lobbyId\": \"" + lobbyId + "\", \"connectedUsers\": [{\"playerId\":\"" + nextIndex + "\", \"playerName\": \"" + ourName + "\"}]}, \"accessToken\": \"asdasdasd123123123\"},\"module\":\"Lobby\",\"type\":\"connect\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(connectMessage);
    }
    
    public void FakeGetDisconnect(Lobby lobby, string playerId)
    {
        var lobbyId = lobby.Id;
        var ourPlayerId = playerId;
        var disconnectMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"disconnectInfo\": {\"lobbyId\": \"" + lobbyId + "\", \"connectedUsers\": [{\"playerId\":\"" + ourPlayerId + "\"}]}},\"module\":\"Lobby\",\"type\":\"disconnect\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(disconnectMessage);
    }
    public void FakeOurCreate(string ourName, GameSettings lobbySettings)
    {
        var createMessage =
            "{\"status\": \"SUCCESS\",\"results\": {\"lobbyInfo\":{\"lobbyId\": \"3\",\"lobbyName\":\"" + lobbySettings.Name +"\", \"maxPlayers\": \"" + lobbySettings.MaxPlayers +"\", \"moveTime\": \"" + lobbySettings.MoveTime +"\", \"ownerInfo\": {\"playerName\": \"" + ourName +"\", \"playerId\": \"1\", \"state\": \"WAITING\"}, \"connectedUsers\": [], \"accessToken\": \"asdasdasdasd123123123\"}}, \"module\":\"Lobby\",\"type\":\"create\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(createMessage);
    }
    
    public void FakeWeReadyLobbyAnswer(Lobby lobby, string playerId)
    {
        var updateMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"updateInfo\": {\"lobbyId\": \"" + lobby.Id +"\", \"connectedUsers\": [{\"playerId\":\"" + playerId +"\", \"state\": \"READY\"}]}},\"module\":\"Lobby\",\"type\":\"update\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(updateMessage);
    }
    
    public void FakeWeNotReadyLobbyAnswer(Lobby lobby, string playerId)
    {
        var updateMessage =
            "{\"status\":\"SUCCESS\",\"results\":{\"updateInfo\": {\"lobbyId\": \"" + lobby.Id +"\", \"connectedUsers\": [{\"playerId\":\"" + playerId +"\", \"state\": \"WAITING\"}]}},\"module\":\"Lobby\",\"type\":\"update\"}";
        ServerLobbyHandler.Instance.FakeOnMessageReceived(updateMessage);
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