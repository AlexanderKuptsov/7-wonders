using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class PlayerData : BaseUserData
    {
        // ----- MAIN -----
        [SerializeField] private Role role;
        public Role Role => role;
        public PlayerData LeftPlayerData { get; private set; }
        public PlayerData RightPlayerData { get; private set; }

        [SerializeField] private MoveStateType moveState; // TODO
        public MoveStateType MoveState => moveState;

        // ----- WONDER CARD -----
        [SerializeField] private WonderCard _wonderCard;

        // ----- CARDS -----
        [SerializeField] private List<CommonCard> inHandCards = new List<CommonCard>();
        public List<CommonCard> InHandCards => inHandCards;

        [SerializeField] private List<CommonCard> activeCards = new List<CommonCard>();
        public List<CommonCard> ActiveCards => activeCards;

        [SerializeField] private CommonCard tempActiveCard;

        // ----- RESOURCES -----
        [SerializeField] private PlayerResources resources = new PlayerResources();
        public PlayerResources Resources => resources;
        public ResourcesCost ResourcesBuyCost { get; } = new ResourcesCost();

        // ----- EVENTS -----
        public EffectsEvents Events = new EffectsEvents();

        public enum MoveStateType
        {
            IN_PROGRESS,
            COMPLETED
        }

        private PlayerData(string id, string name) : base(id, name)
        {
        }

        public PlayerData(string id, string name, Role role) : base(id, name)
        {
            this.role = role;
        }

        public static PlayerData CreateFromUser(UserData userData)
        {
            var player = new PlayerData(userData.Id, userData.Name);
            return player;
        }

        public void MakeAdmin()
        {
            role = Role.ADMIN;
        }

        public void MakeClient()
        {
            role = Role.CLIENT;
        }

        public void SeatBetween(PlayerData leftPlayerData, PlayerData rightPlayerData)
        {
            LeftPlayerData = leftPlayerData;
            RightPlayerData = rightPlayerData;
        }

        public void GiveCards(IEnumerable<CommonCard> cards)
        {
            foreach (var card in cards)
            {
                inHandCards.Add(card);
            }
        }

        public void GiveWonderCard(WonderCard wonderCard)
        {
            _wonderCard = wonderCard;
        }

        public void ActivateCard(CommonCard card)
        {
            tempActiveCard = card;
            inHandCards.Remove(card);
            // TODO -- ui event/action
        }

        public void ThrowCard(CommonCard card)
        {
            inHandCards.Remove(card);

            // TODO -- ui event/action
        }

        public void EndUpMove()
        {
            resources.HandleTemp();
            HandleTempActiveCard();

            Events.NextMoveEffects.Trigger(this);
        }

        public void EndUpEpoch()
        {
            foreach (var activeCard in activeCards)
            {
                ThrowCard(activeCard);
            }

            Events.NextEpochEffects.Trigger(this);
        }

        public void ActivateEndGameBonuses()
        {
            foreach (var activeCard in activeCards)
            {
                activeCard.ActivateEndGameEffect(this);
            }

            Events.EndGameEffects.Trigger(this);
        }

        public PlayerData GetNeighborByDirection(PlayerDirection playerDirection)
        {
            switch (playerDirection)
            {
                case PlayerDirection.RIGHT:
                    return RightPlayerData;
                case PlayerDirection.LEFT:
                    return LeftPlayerData;
                case PlayerDirection.SELF:
                    return this;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerDirection), playerDirection, null);
            }
        }

        public int GetActiveCardCountByType(CommonCardData.CardType cardType) =>
            activeCards.Count(card => card.Data.Type == cardType);

        public bool FindInHandCardById(string cardId, out CommonCard foundCard) =>
            FindCardById(InHandCards, cardId, out foundCard);

        public bool FindActiveCardById(string cardId, out CommonCard foundCard) =>
            FindCardById(ActiveCards, cardId, out foundCard);

        private void HandleTempActiveCard()
        {
            activeCards.Add(tempActiveCard);
            tempActiveCard.Data.Activate();
            tempActiveCard = null;
        }

        private bool FindCardById(IEnumerable<CommonCard> cardsStack, string cardId, out CommonCard foundCard) =>
            NetworkEntity.FindEntityById(cardsStack, cardId, out foundCard);
    }
}