using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;

namespace WhiteTeam.ConnectingUI
{
    public class ScoreElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerHolder;
        [SerializeField] private TMP_Text scoreHolder;

        [SerializeField] private Color winnerColor = Color.yellow;

        public void Setup(ScoreHandler.ScoreData scoreData)
        {
            playerHolder.text = scoreData.Player.Name;
            scoreHolder.text = scoreData.Score.ToString();
        }

        public void SetupWinner()
        {
            playerHolder.color = winnerColor;
            scoreHolder.color = winnerColor;
            playerHolder.fontStyle = FontStyles.Bold;
            scoreHolder.fontStyle = FontStyles.Bold;
        }
    }
}