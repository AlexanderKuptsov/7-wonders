using System;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class UserData : BaseUserData
    {
        public ReadyState state; // TODO

        public UserData(string id, string name, ReadyState state) : base(id, name)
        {
            this.state = state;
        }

        public enum ReadyState
        {
            READY,
            WAITING
        }
    }
}