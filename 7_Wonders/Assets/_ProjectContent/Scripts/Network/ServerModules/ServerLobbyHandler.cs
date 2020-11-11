using System;
using SK_Engine;
using WhiteTeam.GameLogic;

namespace WhiteTeam.Network.ServerModules
{
    public enum LobbyType
    {
        connect,
        disconnect,
        create,
        delete,
        start,
        update
    }

    public class ServerLobbyHandler : ServerModuleHandler<ServerLobbyHandler>
    {
        protected override void OnTextMessageReceived(string text)
        {
            var result = LobbyJsonReceiver.Instance.Deserialize(text);
            var type = AssistanceFunctions.GetEnumByNameUsual<LobbyType>(result.type);
            switch (type)
            {
                case LobbyType.connect:
                    LobbyManager.Instance.OnUserConnectToLobby(result.results.lobbyId, result.results.playerId, result.results.connectInfo.playerName);
                    break;
                case LobbyType.disconnect:
                    LobbyManager.Instance.OnUserDisconnectFromLobby(result.results.lobbyId, result.results.playerId);
                    break;
                case LobbyType.create:
                    LobbyManager.Instance.OnCreateLobby(result.results.lobbyId,
                        result.results.ownerInfo.ownerId, result.results.ownerInfo.ownerName,
                        result.results.lobbyInfo.lobbyName, Int32.Parse(result.results.lobbyInfo.maxPlayers),
                        Int32.Parse(result.results.lobbyInfo.moveTime));
                    break;
                case LobbyType.delete:
                    LobbyManager.Instance.OnDeleteLobby(result.results.lobbyId);
                    break;
                case LobbyType.start:
                    LobbyManager.Instance.OnStartLobby(result.results.lobbyId);
                    break;
                case LobbyType.update:
                    LobbyManager.Instance.OnUpdateLobbies(result.results.lobbyId, result.results.playerId, result.results.updateInfo.state);
                    break;
                default:
                    break;
            }
        }
    }
}