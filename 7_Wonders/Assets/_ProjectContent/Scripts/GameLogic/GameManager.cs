using System;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using Logger = SK_Engine.Logger;

namespace WhiteTeam.GameLogic
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private Logger logger;

        private List<Lobby> _lobbies = new List<Lobby>();
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

        #region NETWORK API

        private void ConnectToLobby(Lobby lobby)
        {
            throw new NotImplementedException();
        }

        public void DisconnectFromLobby()
        {
            throw new NotImplementedException();
        }

        public void CreateLobby()
        {
            if (_lobbies.Count < GameParameters.Instance.MaxLobbies)
            {
                // TODO -- lobby creation request
                throw new NotImplementedException();
            }
        }

        public void DeleteLobby()
        {
            throw new NotImplementedException();
        }

        public void UpdateLobby()
        {
            throw new NotImplementedException();
        }

        public void StartLobby(Lobby lobby)
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
            throw new NotImplementedException();
        }

        public void OnDeleteLobby()
        {
            throw new NotImplementedException();
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