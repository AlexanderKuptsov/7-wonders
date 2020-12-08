using System.Collections.Generic;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.GlobalParameters;

namespace WhiteTeam.GameLogic.Resources
{
    public class ResourcesCost
    {
        private readonly Dictionary<PlayerDirection, Dictionary<Resource.CurrencyProducts, int>> _resources =
            new Dictionary<PlayerDirection, Dictionary<Resource.CurrencyProducts, int>>
            {
                {
                    PlayerDirection.LEFT, new Dictionary<Resource.CurrencyProducts, int>
                    {
                        {Resource.CurrencyProducts.WOOD, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.ORE, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.CLAY, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.STONE, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.PAPYRUS, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.CLOTH, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.GLASS, RulesParameters.Instance.ResourceDefaultBuyCost},
                    }
                },
                {
                    PlayerDirection.RIGHT, new Dictionary<Resource.CurrencyProducts, int>
                    {
                        {Resource.CurrencyProducts.WOOD, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.ORE, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.CLAY, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.STONE, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.PAPYRUS, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.CLOTH, RulesParameters.Instance.ResourceDefaultBuyCost},
                        {Resource.CurrencyProducts.GLASS, RulesParameters.Instance.ResourceDefaultBuyCost},
                    }
                }
            };

        public int GetCost(PlayerDirection playerDirection, Resource.CurrencyProducts currency) =>
            _resources[playerDirection][currency];

        public void SetCost(PlayerDirection playerDirection, Resource.CurrencyProducts currency, int cost)
        {
            _resources[playerDirection][currency] = cost;
        }
    }
}