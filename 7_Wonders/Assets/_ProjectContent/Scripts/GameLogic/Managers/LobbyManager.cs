using System;
using System.Collections.Generic;
using System.Linq;
using SK_Engine;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
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
            public EventHolderBase OnUserConnectToLobby { get; } = new EventHolderBase();
            public EventHolderBase OnUserDisconnectFromLobby { get; } = new EventHolderBase();
            public EventHolderBase OnCreateLobby { get; } = new EventHolderBase();
            public EventHolderBase OnDeleteLobby { get; } = new EventHolderBase();
            public EventHolderBase OnUpdateLobbies { get; } = new EventHolderBase();
            public EventHolderBase OnStartLobby { get; } = new EventHolderBase();
        }

        #region METHODS

        private bool FindLobbyById(string lobbyId, out Lobby lobby)
            => NetworkEntity.FindEntityById(_lobbies, lobbyId, out lobby);

        private bool IsInLobby()
            => _selectedLobby != null;

        #endregion

        #region NETWORK REQUESTS

        public void GetLobbyListRequest()
        {
            var json = LobbyJsonCreator.GetLobbyListJson();
            ServerLobbyHandler.Instance.Send(json);
        }

        public void ConnectToLobbyRequest(Lobby lobby, UserData player)
        {
            var json = LobbyJsonCreator.CreateConnectToLobbyJson(lobby.Id, player.Name);
            ServerLobbyHandler.Instance.Send(json);
            _selectedLobby = lobby;
        }

        public void DisconnectFromLobbyRequest(string lobbyId, string playerId)
        {
            var json = LobbyJsonCreator.CreateDisconnectLobbyJson(lobbyId, playerId);
            ServerLobbyHandler.Instance.Send(json);
        }

        public void CreateLobbyRequest(UserData userData, GameSettings gameSettings)
        {
            if (_lobbies.Count < GameParameters.Instance.MaxLobbies)
            {
                var json = LobbyJsonCreator.CreateCreateLobbyJson(userData, gameSettings);
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

        public void OnUserConnectToLobby(string lobbyId, string playerId, string playerName)
        {
            var newUser = new UserData(playerId, playerName, UserData.ReadyState.WAITING);
            if (FindLobbyById(lobbyId, out var lobby))
            {
                lobby.Connect(newUser);
            }

            Events.OnUserConnectToLobby.TriggerEvents();
        }

        public void OnUserDisconnectFromLobby(string lobbyId, string playerId)
        {
            if (FindLobbyById(lobbyId, out var lobby) &&
                lobby.FindUserById(playerId, out var user))
            {
                lobby.Disconnect(user);
            }

            Events.OnUserDisconnectFromLobby.TriggerEvents();
        }

        public void OnCreateLobby(string lobbyId, string ownerId, string ownerName, string lobbyName, int maxPlayers,
            int moveTime)
        {
            var ownerUser = new UserData(ownerId, ownerName, UserData.ReadyState.WAITING);
            var gameSettings = new GameSettings(lobbyName, maxPlayers, moveTime);
            var lobby = new Lobby(lobbyId, ownerUser, gameSettings);
            _lobbies.Add(lobby);
            logger.Log($"New lobby {lobby.GetFullName()} created.", Logger.LogLevel.INFO);
            Events.OnCreateLobby.TriggerEvents();
        }

        public void OnDeleteLobby(string lobbyId)
        {
            if (FindLobbyById(lobbyId, out var lobbyToDelete))
            {
                _lobbies.Remove(lobbyToDelete);
                logger.Log($"Lobby {lobbyToDelete.GetFullName()} deleted.", Logger.LogLevel.INFO);
            }

            Events.OnDeleteLobby.TriggerEvents();
        }

        public void OnUpdateLobbies(string lobbyId, string playerId, string state)
        {
            if (FindLobbyById(lobbyId, out var lobby) &&
                lobby.FindUserById(playerId, out var user))
            {
                user.state = AssistanceFunctions.GetEnumByName<UserData.ReadyState>(state);
            }

            Events.OnUpdateLobbies.TriggerEvents();
        }

        public void OnStartLobby(string lobbyId)
        {
            if (NetworkEntity.FindEntityById(_lobbies, lobbyId, out var lobbyToStart))
            {
                GameManager.Instance.CreateGameSession(lobbyToStart);
            }

            Events.OnStartLobby.TriggerEvents();
        }

        public void ConnectError()
        {
            _selectedLobby = null;
        }

        #endregion
    }
}