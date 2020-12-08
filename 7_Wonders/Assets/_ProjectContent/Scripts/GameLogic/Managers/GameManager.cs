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
            public EventHolderBase OnNextEpoch { get; } = new EventHolderBase();
            public EventHolderBase OnEndGame { get; } = new EventHolderBase();
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

        private bool IsLocalAction(PlayerData player) => player.Id == CurrentSession.LocalPlayerData.Id;

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
            CurrentSession.GameState.NextMove();

            // TODO -- states
            if (CurrentSession.GameState.IsEpochStart) // next epoch
            {
                if (!CurrentSession.GameState.IsCompleted) // all epochs passed
                {
                    NextEpochRequest();
                }
                else // new epoch
                {
                    EndGameRequest();
                }
            }
            else // next move
            {
                SetupTimer();
            }
        }

        private void NextEpoch(Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            CurrentSession.EndUpEpoch();
            CurrentSession.StartWar();
            GiveCardsInCurrentSession(rawPlayersCardsData);

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

        public void NextMoveRequest()
        {
            if (!IsAdmin()) return;

            ServerGameHandler.Instance.NextMoveRequest(); // TODO
        }

        public void NextEpochRequest()
        {
            if (!IsAdmin()) return;

            ServerGameHandler.Instance.NextEpochRequest(); // TODO
        }

        private void EndGameRequest()
        {
            ServerGameHandler.Instance.EndGameRequest(); // TODO
        }

        public void PlayerActionRequest(INetworkAction action)
        {
            action.SenRequest(); // TODO -- add requests to actions 
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
            NextMove();
            // TODO

            Events.OnNextMove.TriggerEvents();
        }

        private void OnNextEpoch()
        {
            // EXAMPLE
            var rawPlayersCardsData = new Dictionary<string, IEnumerable<string>>
            {
                {"234", new[] {"56465", "6436324"}}
            };

            NextEpoch(rawPlayersCardsData);
            // TODO

            Events.OnNextEpoch.TriggerEvents();
        }

        private void OnEndGame()
        {
            EndGame();
            Events.OnEndGame.TriggerEvents();
        }

        private void OnPlayerCardAction()
        {
            // EXAMPLE
            var playerIdJson = "35215";
            var cardId = "2414";
            var actionJson = "USE";

            if (CurrentSession.FindPlayerById(playerIdJson, out var player) &&
                player.FindInHandCardById(playerIdJson, out var card))
            {
                var actionCommand = AssistanceFunctions.GetEnumByName<CardAction.Command>(actionJson);
                switch (actionCommand)
                {
                    case CardAction.Command.USE:
                        card.Use(player);
                        break;
                    case CardAction.Command.ACTIVATED_USE:
                        card.ActivatedUse(player);
                        break;
                    case CardAction.Command.EXCHANGE:
                        card.Exchange(player);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //CurrentSession.LocalPlayerData.CompleteMove();
                CheckEndMove();

                Events.OnPlayerAction.TriggerEvents();
            }
        }

        private void OnPlayerWonderCardAction()
        {
            // EXAMPLE
            var playerIdJson = "35215";
            var cardId = "2414";
            var actionJson = "BUILD";

            if (CurrentSession.FindPlayerById(playerIdJson, out var player))
            {
                var actionCommand = AssistanceFunctions.GetEnumByName<WonderCardAction.Command>(actionJson);
                switch (actionCommand)
                {
                    case WonderCardAction.Command.BUILD:
                        if (player.FindInHandCardById(playerIdJson, out var card))
                        {
                            player.WonderCard.Use(player);
                            player.ThrowCard(card);

                            CheckEndMove();
                        }
                        else
                        {
                            return; // TODO -- error
                        }

                        break;
                    case WonderCardAction.Command.ACTIVATED_USE:
                        player.WonderCard.ActivatedUse(player);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Events.OnPlayerAction.TriggerEvents();
            }
        }

        private void OnPlayerTradeAction()
        {
            // EXAMPLE
            var playerIdJson = "35215";
            var directionJson = "LEFT";
            var currencyJson = "WOOD";

            if (CurrentSession.FindPlayerById(playerIdJson, out var player))
            {
                var neighborDirection = AssistanceFunctions.GetEnumByName<PlayerDirection>(directionJson);
                var currency = AssistanceFunctions.GetEnumByName<Resource.CurrencyProducts>(currencyJson);

                CurrentSession.Trade(player, neighborDirection, currency);

                // TODO

                Events.OnTradeAction.TriggerEvents();
            }
        }

        #endregion

        private bool IsAdmin() => CurrentSession.Role == Role.ADMIN;
    }
}