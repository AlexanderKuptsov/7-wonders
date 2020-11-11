using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    public class PlayerWrapper : MonoBehaviour
    {
        [ReadOnly] public PlayerData PlayerData;

        public static void CreateFromData(PlayerData data, Transform parent = null)
        {
            var player = new GameObject($"Player_{data.Name}");
            player.transform.SetParent(parent);
            var playerWrapper = player.AddComponent<PlayerWrapper>();
            playerWrapper.PlayerData = data;
        }
    }
}