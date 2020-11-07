using System;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class UserData : BaseUserData
    {
        [SerializeField] private ReadyState state; // TODO
        public ReadyState State => state;

        public UserData(string id, string name) : base(id, name)
        {
        }

        public void SetReady()
        {
            state = ReadyState.READY;
        }

        public void SetWaiting()
        {
            state = ReadyState.WAITING;
        }

        public enum ReadyState
        {
            READY,
            WAITING
        }
    }
}