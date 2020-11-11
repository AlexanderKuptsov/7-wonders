using System;
using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    [Serializable]
    public class CardData
    {
        [ReadOnly] public string Name;
        [ReadOnly] public string SpritePath;
        [ReadOnly] public CardType Type;
        [ReadOnly] public int Epoch;
        [ReadOnly] public Info CostInfo;
        [ReadOnly] public Info[] ActionInfo;

        [Serializable]
        public struct Info
        {
            [ReadOnly] public Resource.Currency Data;
            [ReadOnly] public int Value;
        }
    }

    public enum CardType
    {
        WONDER,
        RAW_MATERIALS,
        MANUFACTURE,
        CIVILIAN,
        SCIENTIFIC,
        COMMERCIAL,
        MILITARY,
        GUILDS
    }
}