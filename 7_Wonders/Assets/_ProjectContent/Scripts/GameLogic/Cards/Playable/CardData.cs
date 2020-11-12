using System;
using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    [Serializable]
    public abstract class CardData
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;
        [ReadOnly] public CardType Type;
        [ReadOnly] public int Epoch;
        [ReadOnly] public Resource.CurrencyItem[] CostInfo;
        [ReadOnly] public string RequirementBuildCard; // TODO

        public abstract void Use(PlayerData player);

        public virtual void ActivateEndGameEffect(PlayerData player)
        {
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