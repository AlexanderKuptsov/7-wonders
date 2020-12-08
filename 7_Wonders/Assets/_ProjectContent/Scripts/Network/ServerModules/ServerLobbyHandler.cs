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
            //var createMessage = "{\"status\":\"SUCCESS\",\"results\":{\"lobbyId\": \"2\", \"ownerInfo\": {\"ownerId\":\"1\", \"ownerName\": \"Aleksei\"},\"lobbyInfo\": {\"lobbyName\":\"newLobby\",\"maxPlayers\":\"5\",\"moveTime\":\"60\"}},\"module\":\"Lobby\",\"type\":\"create\"}";
            var lobbyListMessage =
                "{\"status\": \"SUCCESS\",\"results\": {\"lobbyList\":[ {\"lobbyName\":\"Game 1\", \"maxPlayers\": \"7\", \"moveTime\": \"30\"},{\"lobbyName\":\"Game 2\", \"maxPlayers\": \"6\", \"moveTime\": \"45\"}]},\"module\": \"lobby\",\"type\": \"getLobby\"}";
            //OnTextMessageReceived(lobbyListMessage);
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
                            var gameSettingsList = result.results.lobbyList.Select(info =>
                                new GameSettings(info.lobbyName, Int32.Parse(info.maxPlayers),
                                    Int32.Parse(info.moveTime))).ToArray();
                            var userDataList =
                                result.results.lobbyList.Select(info => new UserData(info.ownerId, info.ownerName))
                                    .ToArray();
                            var lobbyIdList = result.results.lobbyList.Select(info => info.lobbyId).ToArray();
                            LobbyManager.Instance.OnGetLobbyList(lobbyIdList, userDataList, gameSettingsList);
                            break;
                        case LobbyType.connect:
                            LobbyManager.Instance.OnUserConnectToLobby(result.results.connectInfo.lobbyId,
                                result.results.connectInfo.playerId,
                                result.results.connectInfo.playerName);
                            break;
                        case LobbyType.disconnect:
                            LobbyManager.Instance.OnUserDisconnectFromLobby(result.results.disconnectInfo.lobbyId,
                                result.results.disconnectInfo.playerId);
                            break;
                        case LobbyType.create:
                            Debug.Log(result.results.lobbyInfo.lobbyId);
                            Debug.Log(result.results.lobbyInfo.ownerId);
                            Debug.Log(result.results.lobbyInfo.ownerName);
                            Debug.Log(result.results.lobbyInfo.lobbyName);
                            Debug.Log(Int32.Parse(result.results.lobbyInfo.maxPlayers));
                            Debug.Log(result.results.lobbyInfo.moveTime);

                            LobbyManager.Instance.OnCreateLobby(result.results.lobbyInfo.lobbyId,
                                result.results.lobbyInfo.ownerId, result.results.lobbyInfo.ownerName,
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
                                result.results.updateInfo.playerId,
                                result.results.updateInfo.state);
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