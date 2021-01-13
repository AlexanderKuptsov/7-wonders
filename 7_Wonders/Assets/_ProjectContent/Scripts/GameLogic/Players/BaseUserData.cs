using System;
using UnityEngine;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class BaseUserData : INetworkEntity
    {
        [SerializeField] private string id;
        public string Id => id;

        [SerializeField] private string name;
        public string Name => name;

        private IdentifierInfo _identifierInfo;

        public BaseUserData(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void AssignId(string newId)
        {
            id = newId;
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Name));
        }
    }
}