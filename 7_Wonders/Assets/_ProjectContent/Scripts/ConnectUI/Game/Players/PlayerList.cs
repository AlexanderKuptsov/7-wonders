using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;

namespace WhiteTeam.ConnectingUI.Players
{
    public class PlayerList : Singleton<PlayerList>
    {
        [SerializeField] private GameObject playerElement;
        [SerializeField] private Transform playersHolder;

        public void AddPlayers(IEnumerable<PlayerData> players)
        {
            foreach (var player in players)
            {
                AddPlayer(player);
            }
        }

        private void AddPlayer(PlayerData player)
        {
            var playerObject = Instantiate(playerElement.gameObject, playersHolder);
            var playerInfo = playerObject.GetComponent<PlayerInfo>();
            playerInfo.Setup(player);
        }
    }
}