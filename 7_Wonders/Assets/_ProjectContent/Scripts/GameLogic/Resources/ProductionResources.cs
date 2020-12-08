using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Resources
{
    public class ProductionResources
    {
        public Dictionary<Resource.CurrencyProducts, int> Storage { get; private set; } =
            new Dictionary<Resource.CurrencyProducts, int>
            {
                // RawMaterial
                {Resource.CurrencyProducts.WOOD, START_RESOURCE_AMOUNT},
                {Resource.CurrencyProducts.ORE, START_RESOURCE_AMOUNT},
                {Resource.CurrencyProducts.CLAY, START_RESOURCE_AMOUNT},
                {Resource.CurrencyProducts.STONE, START_RESOURCE_AMOUNT},

                // Products
                {Resource.CurrencyProducts.PAPYRUS, START_RESOURCE_AMOUNT},
                {Resource.CurrencyProducts.CLOTH, START_RESOURCE_AMOUNT},
                {Resource.CurrencyProducts.GLASS, START_RESOURCE_AMOUNT},
            };
        
        public void Reset()
        {
            foreach (var currency in Storage.Keys)
            {
                Storage[currency] = START_RESOURCE_AMOUNT;
            }
        }

        private const int START_RESOURCE_AMOUNT = 0;
    }
}