﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Effects;
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

        // ----- CARDS -----
        [SerializeField] private List<Card> inHandCards = new List<Card>();
        public List<Card> InHandCards => inHandCards;

        [SerializeField] private List<Card> activeCards = new List<Card>();
        public List<Card> ActiveCards => activeCards;

        [SerializeField] private Card tempActiveCard;

        // ----- RESOURCES -----
        [SerializeField] private PlayerResources resources = new PlayerResources();
        public PlayerResources Resources => resources;
        public ResourcesCost ResourcesBuyCost { get; } = new ResourcesCost();

        // ----- EVENTS -----
        public List<EffectEvent> NextEpochEffectEvents;
        
        
        
        
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

        public void GiveCards(List<Card> cards)
        {
            inHandCards = cards;
        }

        public void ActivateCard(Card card)
        {
            tempActiveCard = card;
            inHandCards.Remove(card);
            // TODO -- ui event/action
        }

        public void ThrowCard(Card card)
        {
            inHandCards.Remove(card);

            // TODO -- ui event/action
        }

        public void EndUpMove()
        {
            resources.HandleTemp();
            HandleTempActiveCard();
        }

        public void NextEpoch()
        {
            foreach (var effectEvent in NextEpochEffectEvents)
            {
                effectEvent.Effect.Activate(this);
            }

            if (NextEpochEffectEvents.Any(effectEvent => !effectEvent.IsRepeatable))
            {
                NextEpochEffectEvents = NextEpochEffectEvents.Where(effectEvent => effectEvent.IsRepeatable).ToList();
            }
        }

        public void ActivateEndGameBonuses()
        {
            foreach (var activeCard in activeCards)
            {
                activeCard.ActivateEndGameEffect(this);
            }
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

        public int GetActiveCardCountByType(CardType cardType) =>
            activeCards.Count(card => card.Data.Type == cardType);

        public bool FindInHandCardById(string cardId, out Card foundCard) =>
            FindCardById(InHandCards, cardId, out foundCard);

        public bool FindActiveCardById(string cardId, out Card foundCard) =>
            FindCardById(ActiveCards, cardId, out foundCard);

        private void HandleTempActiveCard()
        {
            activeCards.Add(tempActiveCard);
            tempActiveCard = null;
        }

        private bool FindCardById(IEnumerable<Card> cardsStack, string cardId, out Card foundCard) =>
            NetworkEntity.FindEntityById(cardsStack, cardId, out foundCard);
    }
}