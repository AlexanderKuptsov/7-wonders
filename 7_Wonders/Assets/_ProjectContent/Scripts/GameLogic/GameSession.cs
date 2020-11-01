using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network;

namespace WhiteTeam.GameLogic
{
    public class GameSession : MonoBehaviour, INetworkEntity // TODO -- MonoBehaviour?
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Player LocalPlayer { get; private set; }
        public List<Player> Players = new List<Player>();
        public Role Role { get; private set; } // TODO
        
        [SerializeField] private Timer timer;

        private IdentifierInfo _identifierInfo;

        private void Start()
        {
            timer.OnTimerEnd.Subscribe(NextMove);
        }

        public void CreateFromLobby(Lobby lobby)
        {
            Id = lobby.Id;
            Name = lobby.Name;

            LocalPlayer = Player.CreateFromUser(GameManager.Instance.LocalUser);

            Players = lobby.ConnectedUsers.Select(Player.CreateFromUser).ToList();
            Players.Find(player => player.Id == lobby.Owner.Id).MakeAdmin();

            Role = LocalPlayer.Role;

            Setup();
        }

        #region ACTIONS

        private void Setup()
        {
            ProvideSeats();
            SetupTimer();
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

        private void SetupTimer()
        {
            timer.Setup(GameParameters.Instance.MoveTime);
        }

        private bool IsAdmin() => Role == Role.ADMIN;

        #endregion

        #region NETWORK API

        private void NextMove()
        {
            if (!IsAdmin()) return;
            // TODO
        }

        public IdentifierInfo GetIdentifierInfo()
        {
            return _identifierInfo ?? (_identifierInfo = new IdentifierInfo(Id, Name));
        }

        #endregion
    }
}