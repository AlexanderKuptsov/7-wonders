using System;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class UserData : BaseUserData
    {
        public ReadyState state;
        
        public enum ReadyState
        {
            READY,
            WAITING
        }

        public UserData(string id, string name, ReadyState state) : base(id, name)
        {
            this.state = state;
        }

        public UserData(string name) : base("", name)
        {
            state = ReadyState.WAITING;
        }
    }
}