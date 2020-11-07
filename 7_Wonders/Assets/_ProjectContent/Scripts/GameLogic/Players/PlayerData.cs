using System;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class PlayerData : BaseUserData
    {
        [SerializeField] private Role role;
        public Role Role => role;
        public PlayerData LeftPlayerData { get; private set; }
        public PlayerData RightPlayerData { get; private set; }

        [SerializeField] private MoveStateType moveState; // TODO
        public MoveStateType MoveState => moveState;

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

        public PlayerResources Resources => resources;

        [SerializeField] private List<Card> inHandCards = new List<Card>();
        public List<Card> InHandCards => inHandCards;

        [SerializeField] private List<Card> activeCards = new List<Card>();
        public List<Card> ActiveCards => activeCards;

        private PlayerData(string id, string name) : base(id, name)
        {
        }

        public PlayerData(string id, string name, Role role) : base(id, name)
        {
            this.role = role;
        }

        public static PlayerData CreateFromUser(UserData userData)
        {
            var player = new PlayerData(userData.Id, userData.Name);
            return player;
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

        public void GiveCards(List<Card> cards)
        {
            inHandCards = cards;
        }

        public void ActivateCard(Card card)
        {
            inHandCards.Remove(card);
            activeCards.Add(card);
        }

        public enum MoveStateType
        {
            IN_PROGRESS,
            COMPLETED
        }
    }
}