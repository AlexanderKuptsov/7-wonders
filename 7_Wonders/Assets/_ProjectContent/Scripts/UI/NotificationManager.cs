using System;
using TMPro;
using UnityEngine;

namespace WhiteTeam.UI
{
    public class NotificationManager : Singleton<NotificationManager>
    {
        [SerializeField] private PopUpWindow warningWindow;

        public void Warning(string text)
        {
            warningWindow.Object.SetActive(true);
            warningWindow.Text.text = text;
        }

        [Serializable]
        public struct PopUpWindow
        {
            public GameObject Object;
            public TMP_Text Text;
        }
    }
}