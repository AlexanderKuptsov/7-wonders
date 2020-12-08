using System.Collections.Generic;
using System.Linq;
using WhiteTeam.GameLogic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.GameLogic.Resources;
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

        public GameState GameState { get; private set; }

        private PlayerDirection _swipeDirection;
        private IdentifierInfo _identifierInfo;

        public void CreateFromLobby(Lobby lobby)
        {
            Id = lobby.Id;
            Settings = lobby.Settings;

            Players = lobby.ConnectedUsers.Select(PlayerData.CreateFromUser).ToList();
            Players.Find(player => player.Id == lobby.Owner.Id).MakeAdmin();

            LocalPlayerData = Players.Find(player => player.Id == LobbyManager.Instance.LocalUserData.Id);

            Role = LocalPlayerData.Role;
        }

        public void Setup()
        {
            CreatePlayersWrappers();
            ProvideSeats();

            _swipeDirection = RulesParameters.Instance.FirstSwipeDirection;
            GameState = new GameState();
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

        public void GiveWonderCards(Dictionary<PlayerData, WonderCard> playersWonderCardsData)
        {
            foreach (var player in playersWonderCardsData.Keys)
            {
                player.GiveWonderCard(playersWonderCardsData[player]);
            }
        }

        public void GiveCards(Dictionary<PlayerData, IEnumerable<CommonCard>> playersCardsData)
        {
            foreach (var player in playersCardsData.Keys)
            {
                player.GiveCards(playersCardsData[player]);
            }
        }

        public void SwipeCards()
        {
            foreach (var player in Players)
            {
                (_swipeDirection == PlayerDirection.RIGHT
                    ? player.RightPlayerData
                    : player.LeftPlayerData).GiveCards(player.InHandCards);
            }

            _swipeDirection = _swipeDirection == PlayerDirection.RIGHT
                ? PlayerDirection.LEFT
                : PlayerDirection.RIGHT;
        }

        public void Trade(PlayerData player, PlayerDirection playerDirection, Resource.CurrencyProducts currency)
        {
            player.BuyCurrency(playerDirection, currency);
        }

        public bool AllPlayersCompleteMove =>
            Players.All(player => player.MoveState == PlayerData.MoveStateType.COMPLETED);

        public void EndUpMove()
        {
            foreach (var player in Players)
            {
                player.EndUpMove();
            }
        }

        public void EndUpEpoch()
        {
            foreach (var player in Players)
            {
                player.EndUpEpoch();
            }
        }

        public void EndUpGame()
        {
            foreach (var player in Players)
            {
                player.ActivateEndGameBonuses();
            }
        }

        public void StartWar()
        {
            WarHandler.StartWar(Players);
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Settings.Name));
        }

        public bool FindPlayerById(string id, out PlayerData player) =>
            NetworkEntity.FindEntityById(Players, id, out player);
    }
}