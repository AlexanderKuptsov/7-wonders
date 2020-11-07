using System;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class PlayerData : UserData
    {
        [SerializeField] private Role role;
        public Role Role => role;

        public PlayerData LeftPlayerData { get; private set; }
        public PlayerData RightPlayerData { get; private set; }

        [SerializeField] private PlayerResources resources = new PlayerResources
        {
            Money = new Resource(GameParameters.Instance.DefaultResources.Money),
            Science = new Resource(GameParameters.Instance.DefaultResources.Science),
            War = new Resource(GameParameters.Instance.DefaultResources.War),
            Victory = new Resource(GameParameters.Instance.DefaultResources.Victory),
            Conflict = new Resource(GameParameters.Instance.DefaultResources.Conflict),
            IncomeResources = new Resource(0), // TODO
            IncomeProducts = new Resource(0) // TODO
        };

        private PlayerData(string id, string name) : base(id, name)
        {
        }

        public PlayerData(string id, string name, Role role) : base(id, name)
        {
            this.role = role;
        }

        public void MakeAdmin()
        {
            role = Role.ADMIN;
        }

        public void MakeClient()
        {
            role = Role.CLIENT;
        }

        public void SeatBetween(PlayerData leftPlayerData, PlayerData rightPlayerData)
        {
            LeftPlayerData = leftPlayerData;
            RightPlayerData = rightPlayerData;
        }

        public static PlayerData CreateFromUser(UserData userData)
        {
            var player = new PlayerData(userData.Id, userData.Name);
            return player;
        }
    }
}