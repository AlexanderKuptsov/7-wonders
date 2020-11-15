using System;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Utils;
using WhiteTeam.Network.ServerModules;
using Action = WhiteTeam.GameLogic.Actions.Action;

namespace WhiteTeam.GameLogic.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject gameSessionPrototype;

        [SerializeField] private Timer timer;

        public readonly ActionsEvents Events = new ActionsEvents();

        public class ActionsEvents
        {
            public EventHolderBase OnNextMove { get; } = new EventHolderBase();
            public EventHolderBase OnPlayerAction { get; } = new EventHolderBase();
        }

        public GameSession CurrentSession { get; private set; }

        private void Start()
        {
            timer.OnTimerEnd.Subscribe(NextMoveRequest);
        }

        #region ACTIONS

        public void CreateGameSession(Lobby lobby)
        {
            var gameSessionObject = Instantiate(gameSessionPrototype);
            CurrentSession = gameSessionObject.GetComponent<GameSession>();
            CurrentSession.CreateFromLobby(lobby);

            SetupTimer(CurrentSession.Settings.MoveTime);
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

        public void PlayerActionRequest(Action action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region NETWORK EVENTS

        private void OnNextMove()
        {
            throw new NotImplementedException();

            Events.OnNextMove.TriggerEvents();
        }

        private void OnPlayerAction()
        {
            throw new NotImplementedException();

            Events.OnPlayerAction.TriggerEvents();
        }

        #endregion

        private bool IsAdmin() => CurrentSession.Role == Role.ADMIN;
    }
}