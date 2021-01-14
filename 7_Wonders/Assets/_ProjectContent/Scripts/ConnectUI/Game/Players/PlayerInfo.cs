using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.ConnectingUI.Players
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameHolder;

        public PlayerData Data { get; private set; }

        public void Setup(PlayerData data)
        {
            Data = data;
            playerNameHolder.text = Data.Name;
        }

        public void ShowVisualizer()
        {
            PlayerVisualizer.Instance.Show(Data.Name, GetResources(), GetCards(), GetWonderCard());
        }

        public void CloseVisualizer()
        {
            PlayerVisualizer.Instance.Close();
        }

        public void SwitchVisualizer()
        {
            PlayerVisualizer.Instance.SwitchWindow(Data.Name, GetResources(), GetCards(), GetWonderCard());
        }

        public OutputResources GetResources() => Data.Resources.GetCurrentResourcesState();

        public IEnumerable<CommonCard> GetCards() => Data.ActiveCards;

        public WonderCard GetWonderCard() => Data.WonderCard;
    }
}