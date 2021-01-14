using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Managers;

namespace _ProjectContent.Scripts.Network
{
    public class FakeGameServer : Singleton<FakeGameServer>
    {
        private const int CARD_NUMBER = 7;

        public void GameInit(GameSession session)
        {
            // Wonder card
            var wonderCards = new List<WonderCardData>();

            // Common Cards
            var commonCards = new List<CommonCardData>();

            wonderCards.AddRange(new[]
                {
                    WonderCardsBuilder.CreateAlexandriaLighthouse(GenerateId()),
                    WonderCardsBuilder.CreateArtemisTemple(GenerateId()),
                    WonderCardsBuilder.CreateGizaGreatPyramid(GenerateId()),
                    WonderCardsBuilder.CreateHalicarnassusMausoleum(GenerateId()),
                    WonderCardsBuilder.CreateHangingGardens(GenerateId()),
                    WonderCardsBuilder.CreateZeusStatue(GenerateId()),
                    (WonderCardData) WonderCardsBuilder.CreateColloss(GenerateId())
                }
            );

            var rnd = new System.Random();
            var rndWonderCards = wonderCards.OrderBy(x => rnd.Next()).ToList();

            foreach (var player in session.Players)
            {
                for (var i = 0; i < CARD_NUMBER; i++)
                {
                    commonCards.Add(CommonCardBuilder.CreateRandomCard(GenerateId()));
                }
            }

            // Seats
            var seats = session.Players.Select(data => data.Id).ToArray();

            GameManager.Instance.OnGameInit(rndWonderCards, commonCards, seats);
        }

        public void GameStart(GameSession session)
        {
            var rawPlayersWonderCardData = new Dictionary<string, string>(); // playerId - wonder cardId

            var rawPlayersCardsData = GetRandomCards(session.Players);

            for (var index = 0; index < session.Players.Count; index++)
            {
                var player = session.Players[index];
                rawPlayersWonderCardData.Add(player.Id, CardsStack.Instance.WonderCards[index].Data.Id);
            }

            GameManager.Instance.OnGameStart(rawPlayersCardsData, rawPlayersWonderCardData);
        }

        public void NextMove(GameSession session)
        {
            foreach (var player in session.Players.Where(data => data.MoveState == PlayerData.MoveStateType.IN_PROGRESS)
            )
            {
                CommonCard card;
                var availableCards = player.InHandCards.Where(commonCard => commonCard.Data.CanBuy(player))
                    .ToArray();
                if (Random.Range(0, 2) == 0 && availableCards.Length > 0)
                {
                    card = availableCards[Random.Range(0, availableCards.Length)];
                    Debug.Log($"Player ({player.Name}) use card ({card.Data.Name})");
                    card.Use(player);
                    
                    if (player.Id == session.LocalPlayerData.Id)
                    {
                        CardActionsControllerUI.Instance.ActivateCard(card);
                    }
                }
                else
                {
                    card = player.InHandCards[Random.Range(0, player.InHandCards.Count)];
                    Debug.Log($"Player ({player.Name}) exchange card ({card.Data.Name})");
                    card.Exchange(player);
                }

                if (player.Id == session.LocalPlayerData.Id)
                {
                    CardActionsControllerUI.Instance.RemoveLocalInHandCard(card);
                }
            }

            Debug.Log($"Next move ({session.GameState.Move})");
            GameManager.Instance.OnNextMove();
        }

        public void NextEpoch(GameSession session)
        {
            var rawPlayersCardsData = GetRandomCards(session.Players);

            Debug.Log($"Next epoch ({session.GameState.Epoch.ToString()})");
            GameManager.Instance.OnNextEpoch(rawPlayersCardsData);
        }

        public void EndGame(GameSession session)
        {
            GameManager.Instance.OnEndGame();
        }

        private string GenerateId()
        {
            return $"{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}";
        }

        private Dictionary<string, IEnumerable<string>> GetRandomCards(List<PlayerData> players)
        {
            var rawPlayersCardsData = new Dictionary<string, IEnumerable<string>>();
            for (var index = 0; index < players.Count; index++)
            {
                var player = players[index];
                var commonCardsIds = new List<string>();
                for (var i = 0; i < CARD_NUMBER; i++)
                {
                    commonCardsIds.Add(CardsStack.Instance
                        .CommonCards[Random.Range(0, CardsStack.Instance.CommonCards.Count)].Data.Id);
                }

                rawPlayersCardsData.Add(player.Id, commonCardsIds);
            }

            return rawPlayersCardsData;
        }
    }
}