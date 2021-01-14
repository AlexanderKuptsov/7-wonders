using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class WonderCardActionsUI : MonoBehaviour
    {
        [SerializeField] private GameObject cardObject;
        [SerializeField] private WonderCardElement cardElement;

        [SerializeField] private GameObject actionsHolder;

        private PlayerData localPlayer => GameManager.Instance.CurrentSession.LocalPlayerData;

        private bool localPlayerIsMoved => localPlayer.MoveState == PlayerData.MoveStateType.COMPLETED;

        public void Show()
        {
            if (localPlayerIsMoved) return;
            actionsHolder.SetActive(true);
        }

        public void Close()
        {
            actionsHolder.SetActive(false);
        }

        public void Build()
        {
      
        }
    }
}