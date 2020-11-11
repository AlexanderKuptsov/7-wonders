using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic
{
    public class GameSession : MonoBehaviour, INetworkEntity
    {
        public string Id { get; private set; }
        public GameSettings Settings { get; private set; }
        public PlayerData LocalPlayerData { get; private set; }
        public List<PlayerData> Players = new List<PlayerData>();
        public Role Role { get; private set; } // TODO

        [SerializeField] private Transform playersHolder;

        private SwipeDirection _swipeDirection;
        private IdentifierInfo _identifierInfo;

        public void CreateFromLobby(Lobby lobby)
        {
            Id = lobby.Id;
            Settings = lobby.Settings;

            Players = lobby.ConnectedUsers.Select(PlayerData.CreateFromUser).ToList();
            Players.Find(player => player.Id == lobby.Owner.Id).MakeAdmin();

            LocalPlayerData = Players.Find(player => player.Id == LobbyManager.Instance.LocalUserData.Id);

            Role = LocalPlayerData.Role;

            Setup();
        }

        private void Setup()
        {
            CreatePlayersWrappers();
            ProvideSeats();
            _swipeDirection = RulesParameters.Instance.FirstSwipeDirection;
        }

        private void CreatePlayersWrappers()
        {
            var holder = playersHolder ? playersHolder : transform;
            foreach (var playerData in Players)
            {
                PlayerWrapper.CreateFromData(playerData, holder);
            }
        }

        private void ProvideSeats()
        {
            for (var playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                var leftPlayerIndex = playerIndex == 0 ? Players.Count - 1 : playerIndex - 1;
                var rightPlayerIndex = playerIndex == Players.Count - 1 ? 0 : playerIndex + 1;

                Players[playerIndex].SeatBetween(Players[leftPlayerIndex], Players[rightPlayerIndex]);
            }
        }

        public void SwipeCards()
        {
            foreach (var player in Players)
            {
                (_swipeDirection == SwipeDirection.RIGHT
                    ? player.RightPlayerData
                    : player.LeftPlayerData).GiveCards(player.InHandCards);
            }

            _swipeDirection = _swipeDirection == SwipeDirection.RIGHT
                ? SwipeDirection.LEFT
                : SwipeDirection.RIGHT;
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Settings.Name));
        }
        
        public enum SwipeDirection
        {
            RIGHT,
            LEFT
        }
    }
}