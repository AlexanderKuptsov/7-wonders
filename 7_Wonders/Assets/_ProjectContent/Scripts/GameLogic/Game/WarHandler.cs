using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic
{
    public static class WarHandler
    {
        public static Dictionary<GameState.EpochType, int> EpochWarVictoryTokens =
            new Dictionary<GameState.EpochType, int>
            {
                {GameState.EpochType.SECOND, 1},
                {GameState.EpochType.THIRD, 3},
                {GameState.EpochType.COMPLETED, 5},
            };

        public static Dictionary<GameState.EpochType, int> EpochWarLoseTokens = new Dictionary<GameState.EpochType, int>
        {
            {GameState.EpochType.SECOND, 1},
            {GameState.EpochType.THIRD, 1},
            {GameState.EpochType.COMPLETED, 1},
        };

        public static void StartWar(IEnumerable<PlayerData> players)
        {
            Debug.Log("WAR START");
            foreach (var player in players)
            {
                InvadePlayer(player, player.LeftPlayerData);
                InvadePlayer(player, player.RightPlayerData);
            }
        }

        private static void InvadePlayer(PlayerData invader, PlayerData opponent)
        {
            var invaderWarPower = invader.Resources.GetMilitary();
            var opponentWarPower = opponent.Resources.GetMilitary();
            if (invaderWarPower > opponentWarPower)
            {
                invader.Resources.ChangeWarVictoryTokens(
                    EpochWarVictoryTokens[GameManager.Instance.CurrentSession.GameState.Epoch]);
            }
            else if (invaderWarPower < opponentWarPower)
            {
                invader.Resources.ChangeWarLoseTokens(
                    EpochWarLoseTokens[GameManager.Instance.CurrentSession.GameState.Epoch]);
            }
        }
    }
}