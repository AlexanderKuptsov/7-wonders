using System.Collections.Generic;
using MyBox;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class RulesParameters : Singleton<RulesParameters>
    {
        public PlayerDirection FirstSwipeDirection = PlayerDirection.LEFT;
        [PositiveValueOnly] public int CardExchangeAmount = 3;
        [PositiveValueOnly] public int ResourceDefaultBuyCost = 2;

        public Dictionary<GameState.EpochType, int> EpochWarVictoryTokens = new Dictionary<GameState.EpochType, int>
        {
            {GameState.EpochType.FIRST, 1},
            {GameState.EpochType.FIRST, 3},
            {GameState.EpochType.FIRST, 5},
        };
        
        public Dictionary<GameState.EpochType, int> EpochWarLoseTokens = new Dictionary<GameState.EpochType, int>
        {
            {GameState.EpochType.FIRST, 1},
            {GameState.EpochType.FIRST, 1},
            {GameState.EpochType.FIRST, 1},
        };
    }
}