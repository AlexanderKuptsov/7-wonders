using System;
using System.Collections.Generic;
using System.Linq;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic;

namespace WhiteTeam.Network.ServerModules
{
    public enum LobbyType
    {
        getLobby,
        connect,
        disconnect,
        create,
        delete,
        start,
        update
    }


    public class ServerLobbyHandler : ServerModuleHandler<ServerLobbyHandler>
    {
        private void Start()
        {
            
        }
        protected override void OnTextMessageReceived(string text)
        {
            try
            {
                var result = LobbyJsonReceiver.Instance.Deserialize(text);
                var type = AssistanceFunctions.GetEnumByNameUsual<LobbyType>(result.type);
                if (result.IsCorrect)
                {
                    switch (type)
                    {
                        case LobbyType.getLobby:
                            LobbyManager.Instance.OnGetLobbyList(result.results.lobbyList);
                            break;
                        case LobbyType.connect:
                            LobbyManager.Instance.OnUserConnectToLobby(result.results.connectInfo.lobbyId,
                                result.results.connectInfo.connectedUsers[0].playerId,
                                result.results.connectInfo.connectedUsers[0].playerName);
                            break;
                        case LobbyType.disconnect:
                            LobbyManager.Instance.OnUserDisconnectFromLobby(result.results.disconnectInfo.lobbyId,
                                result.results.disconnectInfo.connectedUsers[0].playerId);
                            break;
                        case LobbyType.create:
                            Debug.Log(result.results.lobbyInfo.lobbyId);
                            Debug.Log(result.results.lobbyInfo.ownerInfo.playerId);
                            Debug.Log(result.results.lobbyInfo.ownerInfo.playerName);
                            Debug.Log(result.results.lobbyInfo.lobbyName);
                            Debug.Log(Int32.Parse(result.results.lobbyInfo.maxPlayers));
                            Debug.Log(result.results.lobbyInfo.moveTime);

                            LobbyManager.Instance.OnCreateLobby(result.results.lobbyInfo.lobbyId,
                                result.results.lobbyInfo.ownerInfo.playerId, result.results.lobbyInfo.ownerInfo.playerName,
                                result.results.lobbyInfo.lobbyName, Int32.Parse(result.results.lobbyInfo.maxPlayers),
                                Int32.Parse(result.results.lobbyInfo.moveTime));
                            break;
                        case LobbyType.delete:
                            LobbyManager.Instance.OnDeleteLobby(result.results.deleteInfo.lobbyId);
                            break;
                        case LobbyType.start:
                            LobbyManager.Instance.OnStartLobby(result.results.startCommandInfo.lobbyId);
                            break;
                        case LobbyType.update:
                            LobbyManager.Instance.OnUpdateLobbies(result.results.updateInfo.lobbyId,
                                result.results.updateInfo.connectedUsers[0].playerId,
                                result.results.updateInfo.connectedUsers[0].state);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (result.status == "INVALID_DATA" && type == LobbyType.connect)
                    {
                        LobbyManager.Instance.ConnectError();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log($"Can't parse this msg: {text}");
            }
        }
    }
}