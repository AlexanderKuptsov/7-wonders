using System;
using System.Collections.Generic;
using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;
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
            public EventHolderBase OnTradeAction { get; } = new EventHolderBase();
        }

        public GameSession CurrentSession { get; private set; }

        private void Start()
        {
            timer.OnTimerEnd.Subscribe(NextMoveRequest);
        }

        #region METHODS

        private void SetupTimer()
        {
            timer.Setup(CurrentSession.Settings.MoveTime);
        }

        private Dictionary<PlayerData, IEnumerable<CommonCard>> CreatePlayerCardsData(
            Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            var playersCardsData = new Dictionary<PlayerData, IEnumerable<CommonCard>>();
            foreach (var playerId in rawPlayersCardsData.Keys)
            {
                NetworkEntity.FindEntityById(CurrentSession.Players, playerId, out var player);
                var cards = CardsStack.GetCards(rawPlayersCardsData[playerId]);

                playersCardsData.Add(player, cards);
            }

            return playersCardsData;
        }

        private Dictionary<PlayerData, WonderCard> CreatePlayerWonderCardsData(
            Dictionary<string, string> rawPlayersCardsData)
        {
            var playersCardsData = new Dictionary<PlayerData, WonderCard>();
            foreach (var playerId in rawPlayersCardsData.Keys)
            {
                NetworkEntity.FindEntityById(CurrentSession.Players, playerId, out var player);
                var card = CardsStack.GetWonderCard(rawPlayersCardsData[playerId]);

                playersCardsData.Add(player, card);
            }

            return playersCardsData;
        }

        private void GiveCardsInCurrentSession(Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            var playersCardsData = CreatePlayerCardsData(rawPlayersCardsData);
            CurrentSession.GiveCards(playersCardsData);
        }

        private void GiveCardsInCurrentSession(Dictionary<string, string> rawPlayersWonderCardData)
        {
            var playersWonderCardData = CreatePlayerWonderCardsData(rawPlayersWonderCardData);
            CurrentSession.GiveWonderCards(playersWonderCardData);
        }

        #endregion

        #region ACTIONS

        public void CreateGameSession(Lobby lobby)
        {
            var gameSessionObject = Instantiate(gameSessionPrototype);
            CurrentSession = gameSessionObject.GetComponent<GameSession>();
            CurrentSession.CreateFromLobby(lobby);
        }

        private void StartGame(Dictionary<string, IEnumerable<string>> rawPlayersCardsData,
            Dictionary<string, string> rawPlayersWonderCardData)
        {
            CurrentSession.Setup();

            GiveCardsInCurrentSession(rawPlayersCardsData);
            GiveCardsInCurrentSession(rawPlayersWonderCardData);

            // TODO
            SetupTimer();
        }

        private void NextMove()
        {
            CurrentSession.EndUpMove();
            CurrentSession.SwipeCards();
            // TODO
            SetupTimer();
        }

        private void NextEpoch(Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            // TODO -- NextMove
            CurrentSession.EndUpEpoch();
            CurrentSession.StartWar();
            GiveCardsInCurrentSession(rawPlayersCardsData);
            // TODO
            SetupTimer();
        }

        private void EndGame()
        {
            CurrentSession.EndUpGame();

            var scoreBoard = ScoreHandler.GetScoreBoard(CurrentSession);
            var winner = scoreBoard.GetWinner();
            // TODO
        }

        private void CheckEndMove()
        {
            if (CurrentSession.AllPlayersCompleteMove)
            {
                NextMoveRequest();
            }
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
            CurrentSession.LocalPlayerData.CompleteMove();
            CheckEndMove();
        }

        public void TradeRequest(PlayerDirection playerDirection, Resource.CurrencyProducts currency)
        {
            if (CurrentSession.LocalPlayerData.CanBuyCurrency(playerDirection, currency))
            {
                // TODO -- request
            }
            else
            {
                // TODO -- error
            }
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

        private void OnPlayerTrade()
        {
            throw new NotImplementedException();

            Events.OnTradeAction.TriggerEvents();
        }

        #endregion

        private bool IsAdmin() => CurrentSession.Role == Role.ADMIN;
    }
}