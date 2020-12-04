using System;
using System.Collections.Generic;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Utils;
using WhiteTeam.Network.Entity;
using WhiteTeam.Network.ServerModules;

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

        #region METHODS

        public void CreatePlayerCardsData(
            Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            var playersCardsData = new Dictionary<PlayerData, IEnumerable<CommonCard>>();
            foreach (var playerId in rawPlayersCardsData.Keys)
            {
                NetworkEntity.FindEntityById(CurrentSession.Players, playerId, out var player);
                var cards = CardsStack.GetCards(rawPlayersCardsData[playerId]);

                playersCardsData.Add(player, cards);
            }

            CurrentSession.GiveCards(playersCardsData);
        }

        public void CreatePlayerWonderCardsData(
            Dictionary<string, string> rawPlayersCardsData)
        {
            var playersCardsData = new Dictionary<PlayerData, WonderCard>();
            foreach (var playerId in rawPlayersCardsData.Keys)
            {
                NetworkEntity.FindEntityById(CurrentSession.Players, playerId, out var player);
                var card = CardsStack.GetWonderCard(rawPlayersCardsData[playerId]);

                playersCardsData.Add(player, card);
            }

            CurrentSession.GiveWonderCards(playersCardsData);
        }

        #endregion

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

            ServerGameHandler.Instance.NextMoveRequest(); // TODO
        }

        public void PlayerActionRequest(INetworkAction action)
        {
            action.SenRequest();
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