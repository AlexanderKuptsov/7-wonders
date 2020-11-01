using System.Collections.Generic;
using WhiteTeam.Network;

namespace WhiteTeam.GameLogic.Managers
{
    public class Lobby : INetworkEntity
    {
        public User Owner { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxPlayers { get; private set; }
        public List<User> ConnectedUsers { get; private set; }

        private IdentifierInfo _identifierInfo;

        public Lobby(User owner, int id, string name, int maxPlayers)
        {
            Owner = owner;
            Id = id;
            Name = name;
            MaxPlayers = maxPlayers;
            ConnectedUsers = new List<User>(MaxPlayers);
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

        public int ConnectedUsersCount => ConnectedUsers.Count;

        public bool IsFull => ConnectedUsersCount == MaxPlayers;

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

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Name));
        }
    }
}