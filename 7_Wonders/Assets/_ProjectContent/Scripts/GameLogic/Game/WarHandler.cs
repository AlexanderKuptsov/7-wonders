using System.Collections.Generic;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.GameLogic
{
    public static class WarHandler
    {
        public static void StartWar(IEnumerable<PlayerData> players)
        {
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
                    RulesParameters.Instance.EpochWarVictoryTokens[
                        GameManager.Instance.CurrentSession.GameState.Epoch]);
            }
            else if (invaderWarPower < opponentWarPower)
            {
                invader.Resources.ChangeWarLoseTokens(
                    RulesParameters.Instance.EpochWarLoseTokens[
                        GameManager.Instance.CurrentSession.GameState.Epoch]);
            }
        }
    }
}