using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic
{
    public static class ScoreHandler
    {
        #region API

        public static ScoreBoard GetScoreBoard(GameSession session)
        {
            var scoreBoard = CreateScoreBoard(session.Players);
            return scoreBoard;
        }

        public static ScoreData GetWinnerScore(GameSession session)
        {
            var scoreBoard = CreateScoreBoard(session.Players);

            var winnerScore = scoreBoard.GetWinner();
            return winnerScore;
        }

        #endregion

        #region METHODS

        private static ScoreBoard CreateScoreBoard(IEnumerable<PlayerData> players)
            => new ScoreBoard(players);

        private static int GetPlayerScore(PlayerData player)
        {
            var militaryPoints = CalculateMilitaryScore(player);
            var moneyPoints = CalculateMoneyScore(player);
            var victoryPoints = CalculateVictoryScore(player);
            var sciencePoints = CalculateScienceScore(player);

            var score = militaryPoints + moneyPoints + victoryPoints + sciencePoints;
            return score;
        }

        #endregion

        #region SCORE CALCULATIONS

        private static int CalculateMilitaryScore(PlayerData player)
            => player.Resources.GetWarVictoryTokens() - player.Resources.GetWarLoseTokens();

        private static int CalculateMoneyScore(PlayerData player)
            => player.Resources.GetMoney() / RulesParameters.Instance.MoneyToVictoryPoint;

        private static int CalculateVictoryScore(PlayerData player)
            => player.Resources.GetVictory();

        private static int CalculateScienceScore(PlayerData player)
        {
            var rune1 = player.Resources.GetScience(Resource.Science.RUNE_1);
            var rune2 = player.Resources.GetScience(Resource.Science.RUNE_2);
            var rune3 = player.Resources.GetScience(Resource.Science.RUNE_3);

            var score = 0;
            // SAME RUNES POINTS
            score += rune1 * rune1;
            score += rune2 * rune2;
            score += rune3 * rune3;

            // DIFFERENT RUNES GROUPS POINTS
            score += Mathf.Min(rune1, rune2, rune3) * RulesParameters.Instance.DifferentScienceGroupModifier;

            return score;
        }

        #endregion

        #region SCORE DATA HOLDERS

        public readonly struct ScoreBoard
        {
            private readonly ScoreData[] _elements;

            public ScoreBoard(IEnumerable<PlayerData> players)
            {
                _elements = players.Select(player => new ScoreData {Player = player, Score = GetPlayerScore(player)})
                    .OrderByDescending(data => data.Score)
                    .ToArray();
            }

            public ScoreData[] Elements => _elements;

            public ScoreData GetWinner()
            {
                return _elements.FirstOrDefault();
            }

            public ScoreData GetLoser()
            {
                return _elements.LastOrDefault();
            }
        }

        public struct ScoreData
        {
            public PlayerData Player;
            public int Score;
        }

        #endregion
    }
}