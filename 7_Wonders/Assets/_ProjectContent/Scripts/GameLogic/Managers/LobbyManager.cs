using System;
using System.Collections.Generic;
using System.Linq;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.GameLogic.Token;
using WhiteTeam.Network.Entity;
using WhiteTeam.Network.ServerModules;
using Logger = SK_Engine.Logger;

namespace WhiteTeam.GameLogic
{
    public class LobbyManager : Singleton<LobbyManager>
    {
        [SerializeField] private Logger logger;

        public readonly List<Lobby> _lobbies = new List<Lobby>();
        private Lobby _selectedLobby;

        public UserData LocalUserData;

        // EVENTS
        public readonly ActionsEvents Events = new ActionsEvents();

        public class ActionsEvents
        {
            public EventHolderBase OnGetLobbyListToLobby { get; } = new EventHolderBase();
            public EventHolder<string> OnUserConnectToLobby { get; } = new EventHolder<string>();
            public EventHolder<string> OnUserDisconnectFromLobby { get; } = new EventHolder<string>();
            public EventHolderBase OnCreateLobby { get; } = new EventHolderBase();
            public EventHolderBase OnDeleteLobby { get; } = new EventHolderBase();
            public EventHolder<string> OnUpdateLobbies { get; } = new EventHolder<string>();
            public EventHolderBase OnStartLobby { get; } = new EventHolderBase();
            
        }

        #region METHODS

        private bool FindLobbyById(string lobbyId, out Lobby lobby)
            => NetworkEntity.FindEntityById(_lobbies, lobbyId, out lobby);

        private bool IsInLobby => _selectedLobby != null;
        

        #endregion

        #region NETWORK REQUESTS

        public void GetLobbyListRequest()
        {
            var json = LobbyJsonCreator.GetLobbyListJson();
            Debug.Log(json);
            ServerLobbyHandler.Instance.Send(json);
        }

        public void ConnectToLobbyRequest(Lobby lobby, string playerName)
        {
            var json = LobbyJsonCreator.CreateConnectToLobbyJson(lobby.Id, playerName, TokenHolder.Instance.Token);
            ServerLobbyHandler.Instance.Send(json);
            _selectedLobby = lobby;
        }

        public void DisconnectFromLobbyRequest(string lobbyId, string playerId)
        {
            var json = LobbyJsonCreator.CreateDisconnectLobbyJson(lobbyId, playerId);
            ServerLobbyHandler.Instance.Send(json);
        }

        public void CreateLobbyRequest(string playerName, GameSettings gameSettings)
        {
            if (_lobbies.Count < GameParameters.Instance.MaxLobbies)
            {
                var json = LobbyJsonCreator.CreateCreateLobbyJson(playerName, gameSettings, TokenHolder.Instance.Token);
                ServerLobbyHandler.Instance.Send(json);
            }
        }

        public void DeleteLobbyRequest(string lobbyId)
        {
            var json = LobbyJsonCreator.CreateDeleteLobbyJson(lobbyId);
            ServerLobbyHandler.Instance.Send(json);
        }

        public void UpdateLobbyRequest(string lobbyId, string playerId, bool state)
        {
            var json = LobbyJsonCreator.CreateUpdateLobbyJson(lobbyId, playerId, state.ToString());
            ServerLobbyHandler.Instance.Send(json);
        }

        public void StartLobbyRequest(Lobby lobby)
        {
            if (lobby.ConnectedUsers.Count > 1)
            {
                var json = LobbyJsonCreator.CreateStartLobbyJson(lobby.Id);
                ServerLobbyHandler.Instance.Send(json);
            }
        }

        #endregion

        #region NETWORK EVENTS

        public void OnGetLobbyList(CreationLobbyInfo[] lobbyInfo)
        {
            for (int i = 0; i < lobbyInfo.Length; i++)
            {
                _lobbies.Add(new Lobby(lobbyInfo[i].lobbyId,
                    new UserData(lobbyInfo[i].ownerInfo.playerId, lobbyInfo[i].ownerInfo.playerName,
                        AssistanceFunctions.GetEnumByName<UserData.ReadyState>(lobbyInfo[i].ownerInfo.state)),
                    new GameSettings(lobbyInfo[i].lobbyName, Int32.Parse(lobbyInfo[i].maxPlayers),
                        Int32.Parse(lobbyInfo[i].moveTime)),
                    lobbyInfo[i].connectedUsers.Select(user => new UserData(user.playerId, user.playerName,
                        AssistanceFunctions.GetEnumByName<UserData.ReadyState>(user.state)))));
            }

            Debug.Log($"{_lobbies.Count} lobbies were created");
            Events.OnGetLobbyListToLobby.TriggerEvents();
        }

        public void OnUserConnectToLobby(string lobbyId, string playerId, string playerName, string sessionId)
        {
            var newUser = new UserData(playerId, playerName, UserData.ReadyState.WAITING);
           
            
            if (FindLobbyById(lobbyId, out var lobby))
            {
                lobby.Connect(newUser);
                
                
                //FAKE CUZ WE NEED TO CONNECT US TODO TODO TODO
                _selectedLobby = lobby;
                LocalUserData.AssignId(playerId);
            }

            if (sessionId == TokenHolder.Instance.Token)
            {
                LocalUserData = newUser;
            }
            Events.OnUserConnectToLobby.TriggerEvents(lobbyId);
        }

        public void OnUserDisconnectFromLobby(string lobbyId, string playerId)
        {
            if (FindLobbyById(lobbyId, out var lobby) &&
                lobby.FindUserById(playerId, out var user))
            {
                lobby.Disconnect(user);
                Events.OnUserDisconnectFromLobby.TriggerEvents(lobbyId);
            }
        }

        public void OnCreateLobby(CreationLobbyInfo lobbyInfo)
        {
            _lobbies.Add(new Lobby(lobbyInfo.lobbyId,
                new UserData(lobbyInfo.ownerInfo.playerId, lobbyInfo.ownerInfo.playerName,
                    AssistanceFunctions.GetEnumByName<UserData.ReadyState>(lobbyInfo.ownerInfo.state)),
                new GameSettings(lobbyInfo.lobbyName, Int32.Parse(lobbyInfo.maxPlayers),
                    Int32.Parse(lobbyInfo.moveTime)),
                lobbyInfo.connectedUsers.Select(user => new UserData(user.playerId, user.playerName,
                    AssistanceFunctions.GetEnumByName<UserData.ReadyState>(user.state)))));
            Debug.Log($"Lobby was created. Now there are {_lobbies.Count} lobbies");
            Events.OnCreateLobby.TriggerEvents();
        }

        public void OnDeleteLobby(string lobbyId)
        {
            if (FindLobbyById(lobbyId, out var lobbyToDelete))
            {
                _lobbies.Remove(lobbyToDelete);
                logger.Log($"Lobby {lobbyToDelete.GetFullName()} deleted.", Logger.LogLevel.INFO);

                Events.OnDeleteLobby.TriggerEvents();
            }
        }

        public void OnUpdateLobbies(string lobbyId, string playerId, string state)
        {
            if (FindLobbyById(lobbyId, out var lobby) &&
                lobby.FindUserById(playerId, out var user))
            {
                user.state = AssistanceFunctions.GetEnumByName<UserData.ReadyState>(state);
                if (user.Id == LocalUserData.Id && lobbyId == lobby.Id)
                {
                    LocalUserData.state = AssistanceFunctions.GetEnumByName<UserData.ReadyState>(state);
                }
                Events.OnUpdateLobbies.TriggerEvents(lobbyId);

                if (lobby.AllUsersReady)
                {
                    StartLobbyRequest(lobby);
                }
            }
        }

        public void OnStartLobby(string lobbyId)
        {
            if (FindLobbyById(lobbyId, out var lobbyToStart))
            {
                if (lobbyToStart == _selectedLobby)
                {
                    GameManager.Instance.CreateGameSession(lobbyToStart);
                }

                OnDeleteLobby(lobbyId); // TODO

                Events.OnStartLobby.TriggerEvents();
            }
        }

        public void ConnectError()
        {
            _selectedLobby = null;
        }

        #endregion
    }
}