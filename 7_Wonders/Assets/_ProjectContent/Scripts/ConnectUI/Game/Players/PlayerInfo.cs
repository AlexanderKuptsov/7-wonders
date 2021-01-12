using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.ConnectingUI.Players
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private PlayerVisualizer visualizer;

        public PlayerData Data { get; private set; }

        public void Setup(PlayerData data)
        {
            Data = data;
            UpdateVisualizer();
        }

        public void UpdateVisualizer()
        {
            visualizer.Setup(GetResources(), GetCards(), GetWonderCard());
        }

        public OutputResources GetResources() => Data.Resources.GetCurrentResourcesState();

        public IEnumerable<CommonCard> GetCards() => Data.ActiveCards;

        public WonderCard GetWonderCard() => Data.WonderCard;
    }
}