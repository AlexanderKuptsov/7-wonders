using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.Entity;
using Logger = SK_Engine.Logger;

namespace WhiteTeam.GameLogic
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private Logger logger;

        private readonly List<Lobby> _lobbies = new List<Lobby>();
        private Lobby _selectedLobby;

        public User LocalUser;

        private void Start()
        {
            //LocalUser = new User(GameParameters.Instance.DefaultUserName);
        }

        #region METHODS

        private void ConnectLocalUser(Lobby lobby) // TODO
        {
            if (lobby.Connect(LocalUser))
            {
                logger.Log("Connected to lobby", Logger.LogLevel.INFO);
            }
            else
            {
                logger.Log("Can't connect to lobby", Logger.LogLevel.INFO);
            }
        }

        #endregion

        #region NETWORK REQUESTS

        private void ConnectToLobbyRequest(Lobby lobby)
        {
            throw new NotImplementedException();
        }

        public void DisconnectFromLobbyRequest()
        {
            throw new NotImplementedException();
        }

        public void CreateLobbyRequest()
        {
            if (_lobbies.Count < GameParameters.Instance.MaxLobbies)
            {
                // TODO -- lobby creation request
                throw new NotImplementedException();
            }
        }

        public void DeleteLobbyRequest()
        {
            throw new NotImplementedException();
        }

        public void UpdateLobbyRequest()
        {
            throw new NotImplementedException();
        }

        public void StartLobbyRequest(Lobby lobby)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region NETWORK EVENTS

        public void OnUserConnectToLobby()
        {
            //LocalUser = new User(GameParameters.Instance.DefaultUserName);
            throw new NotImplementedException();
        }

        public void OnUserDisconnectFromLobby()
        {
            throw new NotImplementedException();
        }

        public void OnCreateLobby()
        {
            // EXAMPLE
            var lobbyId = "321";

            var ownerId = "123";
            var ownerName = "Owner";
            var ownerUser = new User(ownerId, ownerName);

            var lobbyName = "Lobby";
            var maxPlayers = 5;
            var moveTime = 60;
            var settings = new GameSettings(lobbyName, maxPlayers, moveTime);

            var connectedUsersData = new Dictionary<string, string>
            {
                {"325425", "bot1"},
                {"235552", "bot2"}
            };
            var connectedUsers = connectedUsersData
                .Select(userData => new User(userData.Key, userData.Value));

            var lobby = new Lobby(lobbyId, ownerUser, settings, connectedUsers);
            _lobbies.Add(lobby);
            logger.Log($"New lobby {lobby.GetFullName()} created.", Logger.LogLevel.INFO);
        }

        public void OnDeleteLobby()
        {
            // EXAMPLE
            var lobbyId = "321";
            var lobbyToDelete = NetworkEntity.GetEntityById(_lobbies, lobbyId);
            if (lobbyToDelete != null)
            {
                _lobbies.Remove(lobbyToDelete);
                logger.Log($"Lobby {lobbyToDelete.GetFullName()} deleted.", Logger.LogLevel.INFO);
            }
        }

        public void OnUpdateLobbies()
        {
            throw new NotImplementedException();
        }

        public void OnStartLobby()
        {
            // TODO -- create GameSession, assign admin role
            throw new NotImplementedException();
        }

        #endregion
    }
}