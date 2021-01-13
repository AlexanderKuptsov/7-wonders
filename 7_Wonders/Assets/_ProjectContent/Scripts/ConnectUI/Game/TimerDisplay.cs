using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic.Utils;

namespace WhiteTeam.ConnectingUI
{
    public class TimerDisplay : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private TMP_Text textHolder;
        
        private void Start()
        {
            UpdateTextHolder();
        }

        private void Update()
        {
            if (timer.IsWorking)
            {
                UpdateTextHolder();
            }
        }

        private void UpdateTextHolder()
        {
            textHolder.text = timer.RemainingTime.ToString("F1");
        }
    }
}