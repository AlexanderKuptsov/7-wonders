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

        private string GenerateId()
        {
            return $"{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}";
        }

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
            var rawPlayersCardsData = new Dictionary<string, IEnumerable<string>>(); // playerId - common cardsId
            var rawPlayersWonderCardData = new Dictionary<string, string>(); // playerId - wonder cardId

            for (var index = 0; index < session.Players.Count; index++)
            {
                var player = session.Players[index];
                var commonCardsIds = new List<string>();
                for (var i = 0; i < CARD_NUMBER; i++)
                {
                    commonCardsIds.Add(CardsStack.Instance
                        .CommonCards[Random.Range(0, CardsStack.Instance.CommonCards.Count)].Data.Id);
                }

                rawPlayersCardsData.Add(player.Id, commonCardsIds);
                rawPlayersWonderCardData.Add(player.Id, CardsStack.Instance.WonderCards[index].Data.Id);
            }

            GameManager.Instance.OnGameStart(rawPlayersCardsData, rawPlayersWonderCardData);
        }
    }
}