using System.Collections.Generic;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Managers
{
    public class Lobby : INetworkEntity
    {
        public string Id { get; private set; }
        public User Owner { get; private set; }
        public GameSettings Settings { get; private set; }
        public List<User> ConnectedUsers { get; private set; }

        private IdentifierInfo _identifierInfo;

        public Lobby(string id, User owner, GameSettings settings)
        {
            LobbySetup(id, owner, settings);
        }

        public Lobby(string id, User owner, GameSettings settings, IEnumerable<User> connectedUsers)
        {
            LobbySetup(id, owner, settings);
            ConnectedUsers.AddRange(connectedUsers);
        }

        private void LobbySetup(string id, User owner, GameSettings settings)
        {
            Id = id;
            Owner = owner;
            Settings = settings;
            ConnectedUsers = new List<User>(Settings.MaxPlayers) {Owner};
        }

        #region API

        public bool Connect(User user)
        {
            if (IsFull || ConnectedUsers.Contains(user)) return false;
            AddUser(user);
            return true;
        }

        public void Leave(User user)
        {
            RemoveUser(user);
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Settings.Name));
        }

        public string GetFullName() => $"(id: {Id}, name: {Settings.Name})";

        public int ConnectedUsersCount => ConnectedUsers.Count;

        public bool IsFull => ConnectedUsersCount == Settings.MaxPlayers;

        #endregion

        #region METHODS

        private void AddUser(User user)
        {
            ConnectedUsers.Add(user);
        }

        private void RemoveUser(User user)
        {
            ConnectedUsers.Remove(user);
        }

        #endregion
    }
}