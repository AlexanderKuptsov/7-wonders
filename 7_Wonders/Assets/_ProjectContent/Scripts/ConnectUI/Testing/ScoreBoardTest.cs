using System.Collections.Generic;
using MyBox;
using UnityEngine;
using WhiteTeam.ConnectingUI;
using WhiteTeam.GameLogic;
using Random = UnityEngine.Random;

public class ScoreBoardTest : MonoBehaviour
{
    [SerializeField] private int playerCount = 5;

    [SerializeField] private ScoreBoardDisplay scoreBoardDisplay;


    private void Start()
    {
        GenerateScoreBoard();
    }

    private PlayerData GeneratePlayer()
    {
        var playerId = $"{Random.Range(1, 1000)}-{Random.Range(1, 1000)}-{Random.Range(1, 1000)}";
        var playerName = $"Player {Random.Range(1, 1000)}";
        var player = new PlayerData(playerId, playerName, Role.CLIENT);

        player.Resources.ChangeMoney(Random.Range(0, 30));
        player.Resources.ChangeVictory(Random.Range(0, 30));

        return player;
    }
    
#if UNITY_EDITOR
    [ButtonMethod]
    private string GenerateScoreBoard()
    {
        var players = new List<PlayerData>(playerCount);
        for (var i = 0; i < playerCount; i++)
        {
            players.Add(GeneratePlayer());
        }

        var scoreBoard = new ScoreHandler.ScoreBoard(players);

        scoreBoardDisplay.Show(scoreBoard);
        return $"ScoreBoard ({scoreBoard})";
    }
#endif
    
#if UNITY_EDITOR
    [ButtonMethod]
    private string CloseScoreBoard()
    {
        scoreBoardDisplay.Close();
        return $"ScoreBoard closed";
    }
#endif
}