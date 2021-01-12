using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.ConnectingUI.Players
{
    public class PlayerInfo : MonoBehaviour
    {
        public PlayerData Data { get; private set; }

        public void Setup(PlayerData data)
        {
            Data = data;
        }

        public OutputResources GetResources() => Data.Resources.GetCurrentResourcesState();
    }
}