using System;
using System.Collections.Generic;
using System.Linq;
using _ProjectContent.Scripts.Network;
using SK_Engine;
using UnityEngine;
using WhiteTeam.ConnectingUI;
using WhiteTeam.ConnectingUI.Cards;
using WhiteTeam.ConnectingUI.Players;
using WhiteTeam.GameLogic.Actions;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;
using WhiteTeam.GameLogic.Token;
using WhiteTeam.GameLogic.Utils;
using WhiteTeam.Network.Entity;
using WhiteTeam.Network.ServerModules;

namespace WhiteTeam.GameLogic.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject gameSessionPrototype;

        [SerializeField] private Timer timer;

        [SerializeField] private ScoreBoardDisplay scoreBoardDisplay;

        public readonly ActionsEvents Events = new ActionsEvents();

        public class ActionsEvents
        {
            public EventHolderBase OnGameInit { get; } = new EventHolderBase();
            public EventHolderBase OnGameStart { get; } = new EventHolderBase();
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

            CreateGameSession(TokenHolder.Instance.PlayableLobby);
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
                var cards = CardsStack.Instance.GetCards(rawPlayersCardsData[playerId]);

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
                var card = CardsStack.Instance.GetWonderCard(rawPlayersCardsData[playerId]);

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

            //GameStartRequest();
            GameInitRequest();
        }

        private void StartGame(Dictionary<string, IEnumerable<string>> rawPlayersCardsData,
            Dictionary<string, string> rawPlayersWonderCardData)
        {
            CurrentSession.Setup();

            GiveCardsInCurrentSession(rawPlayersCardsData);
            GiveCardsInCurrentSession(rawPlayersWonderCardData);

            // TODO
            SetupTimer();

            SetupUI();
        }

        private void SetupUI()
        {
            PlayerList.Instance.AddPlayers(
                CurrentSession.Players.Where(data => data.Id != CurrentSession.LocalPlayerData.Id));
            CardVisualizationController.Instance.AddInHandCards(CurrentSession.LocalPlayerData.InHandCards);
            WonderCardGameSetup.Instance.GlobalSetup(CurrentSession.LocalPlayerData.WonderCard);

            UpdateLocalResources.Instance.Sync();
            UpdateNeighboursResources.Instance.Sync();
            UpdateNeighboursResources.Instance.Sync();
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
                else
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

            CardVisualizationController.Instance.AddInHandCards(CurrentSession.LocalPlayerData.InHandCards);
            Debug.Log($"In hand {CurrentSession.LocalPlayerData.InHandCards.Count}");
            
            SetupTimer();
        }

        private void EndGame()
        {
            CurrentSession.EndUpGame();

            var scoreBoard = ScoreHandler.GetScoreBoard(CurrentSession);

            scoreBoardDisplay.Show(scoreBoard);
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

        public void GameInitRequest()
        {
            //if (!IsAdmin()) return;

            //ServerGameHandler.Instance.GameInitRequest(); // TODO put lobby id here

            FakeGameServer.Instance.GameInit(CurrentSession);
        }

        public void GameStartRequest()
        {
            //if (!IsAdmin()) return;

            //ServerGameHandler.Instance.GameStartRequest(); // TODO put game id here

            FakeGameServer.Instance.GameStart(CurrentSession);
        }

        public void NextMoveRequest()
        {
            //if (!IsAdmin()) return;

            //ServerGameHandler.Instance.NextMoveRequest(); // TODO put game id here

            FakeGameServer.Instance.NextMove(CurrentSession);
        }

        public void NextEpochRequest()
        {
            //if (!IsAdmin()) return;

            //ServerGameHandler.Instance.NextEpochRequest(); // TODO put game id here

            FakeGameServer.Instance.NextEpoch(CurrentSession);
        }

        private void EndGameRequest()
        {
            //if (!IsAdmin()) return;
            //ServerGameHandler.Instance.EndGameRequest(); // TODO

            FakeGameServer.Instance.EndGame(CurrentSession);
        }

        public void PlayerActionRequest(INetworkAction action)
        {
            action.SenRequest(); // TODO put game id here
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

        public void OnGameInit(List<WonderCardData> wonderCards, List<CommonCardData> commonCards, string[] seats)
        {
            CardsStack.Instance.LoadWonderCards(wonderCards);
            CardsStack.Instance.LoadCards(commonCards);
            CurrentSession.ProvideSeats(seats);

            // TODO
            GameStartRequest();

            Events.OnGameInit.TriggerEvents();
        }

        public void OnGameStart(Dictionary<string, IEnumerable<string>> rawPlayersCardsData,
            Dictionary<string, string> rawPlayersWonderCardData)
        {
            StartGame(rawPlayersCardsData, rawPlayersWonderCardData);
            // TODO
            Events.OnGameStart.TriggerEvents();
        }

        public void OnNextMove()
        {
            NextMove();
            // TODO

            Events.OnNextMove.TriggerEvents();
        }

        public void OnNextEpoch(Dictionary<string, IEnumerable<string>> rawPlayersCardsData)
        {
            NextEpoch(rawPlayersCardsData);
            // TODO

            Events.OnNextEpoch.TriggerEvents();
        }

        public void OnEndGame()
        {
            EndGame();
            Events.OnEndGame.TriggerEvents();
        }

        public void OnPlayerCardAction()
        {
            // TODO - EXAMPLE
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

        public void OnPlayerWonderCardAction()
        {
            // TODO - EXAMPLE
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

        public void OnPlayerTradeAction()
        {
            // TODO - EXAMPLE
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