using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class RulesParameters : Singleton<RulesParameters>
    {
        public PlayerDirection FirstSwipeDirection = PlayerDirection.LEFT;
        [PositiveValueOnly] public int CardExchangeAmount = 3;
        [PositiveValueOnly] public int ResourceDefaultBuyCost = 2;

        [Header("Score")] public int MoneyToVictoryPoint = 3;
        public int DifferentScienceGroupModifier = 7;

        public Dictionary<GameState.EpochType, int> EpochWarVictoryTokens = new Dictionary<GameState.EpochType, int>
        {
            {GameState.EpochType.FIRST, 1},
            {GameState.EpochType.SECOND, 3},
            {GameState.EpochType.THIRD, 5},
        };

        public Dictionary<GameState.EpochType, int> EpochWarLoseTokens = new Dictionary<GameState.EpochType, int>
        {
            {GameState.EpochType.FIRST, 1},
            {GameState.EpochType.SECOND, 1},
            {GameState.EpochType.THIRD, 1},
        };
    }
}