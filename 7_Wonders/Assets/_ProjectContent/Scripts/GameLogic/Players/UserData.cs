using System;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class UserData : BaseUserData
    {
        public ReadyState state; // TODO

        public UserData(string id, string name) : base(id, name)
        {
        }

        public enum ReadyState
        {
            READY,
            WAITING
        }
    }
}