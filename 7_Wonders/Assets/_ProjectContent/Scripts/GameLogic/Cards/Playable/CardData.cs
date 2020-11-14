using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public CardData(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo, string requirementBuildCard)
        {
            Id = id;
            Name = name;
            Type = type;
            Epoch = epoch;
            CostInfo = costInfo;
            RequirementBuildCard = requirementBuildCard;
        }
        
        public abstract void Use(PlayerData player);

        public virtual void ActivateEndGameEffect(PlayerData player)
        {
        }

        public IEnumerable<PropertyInfo> GetSelfProperties()
        {
            return Assembly
                .GetAssembly(typeof(CardData))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CardData))).SelectMany(t => t.GetProperties());
        }
    }

    public enum CardType
    {
        RAW_MATERIALS,
        MANUFACTURE,
        CIVILIAN,
        SCIENTIFIC,
        COMMERCIAL,
        MILITARY,
        GUILDS
    }
}