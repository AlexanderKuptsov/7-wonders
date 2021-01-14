using System;
using System.Collections.Generic;
using System.Linq;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Managers
{
    [Serializable]
    public class Lobby : INetworkEntity
    {
        public string Id { get; private set; }
        public UserData Owner { get; private set; }
        public GameSettings Settings { get; private set; }
        public List<UserData> ConnectedUsers;//{ get; private set; }

        private IdentifierInfo _identifierInfo;

        public Lobby(string id, UserData owner, GameSettings settings)
        {
            LobbySetup(id, owner, settings);
        }

        public Lobby(string id, UserData owner, GameSettings settings, IEnumerable<UserData> connectedUsers)
        {
            LobbySetup(id, owner, settings);
            ConnectedUsers.AddRange(connectedUsers);
        }

        private void LobbySetup(string id, UserData owner, GameSettings settings)
        {
            Id = id;
            Owner = owner;
            Settings = settings;
            ConnectedUsers = new List<UserData>(Settings.MaxPlayers) {Owner};
        }

        #region API

        public bool Connect(UserData userData)
        {
            if (IsFull || ConnectedUsers.Contains(userData)) return false;
            AddUser(userData);
            return true;
        }

        public void Disconnect(UserData userData)
        {
            RemoveUser(userData);
        }

        public bool FindUserById(string userId, out UserData user) =>
            NetworkEntity.FindEntityById(ConnectedUsers, userId, out user);


        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Settings.Name));
        }

        public string GetFullName() => $"(id: {Id}, name: {Settings.Name})";

        public int ConnectedUsersCount => ConnectedUsers.Count;

        public bool IsFull => ConnectedUsersCount == Settings.MaxPlayers;

        public bool AllUsersReady => ConnectedUsers.Count == Settings.MaxPlayers &&
                                     ConnectedUsers.All(user => user.state == UserData.ReadyState.READY);

        #endregion

        #region METHODS

        private void AddUser(UserData userData)
        {
            ConnectedUsers.Add(userData);
        }

        private void RemoveUser(UserData userData)
        {
            ConnectedUsers.Remove(userData);
        }

        #endregion
    }
}