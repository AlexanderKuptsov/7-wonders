using System;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Utils;
using WhiteTeam.Network.ServerModules;

namespace WhiteTeam.GameLogic.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject gameSessionPrototype;

        [SerializeField] private Timer timer;

        public readonly ActionsEvents Events = new ActionsEvents();

        private GameSession _currentSession;

        private void Start()
        {
            timer.OnTimerEnd.Subscribe(NextMoveRequest);
        }

        #region ACTIONS

        public void CreateGameSession(Lobby lobby)
        {
            var gameSessionObject = Instantiate(gameSessionPrototype);
            _currentSession = gameSessionObject.GetComponent<GameSession>();
            _currentSession.CreateFromLobby(lobby);

            SetupTimer(_currentSession.Settings.MoveTime);
        }

        private void SetupTimer(int moveTime)
        {
            timer.Setup(moveTime);
        }

        #endregion

        #region NETWORK REQUESTS

        private void NextMoveRequest()
        {
            if (!IsAdmin()) return;

            ServerGameHandler.Instance.NextMoveRequest();
        }

        #endregion

        #region NETWORK EVENTS

        private void OnNextMove()
        {
            throw new NotImplementedException();
            Events.OnNextMove.TriggerEvents();
        }

        #endregion

        public class ActionsEvents
        {
            public EventHolderBase OnNextMove { get; } = new EventHolderBase();
        }

        private bool IsAdmin() => _currentSession.Role == Role.ADMIN;
    }
}