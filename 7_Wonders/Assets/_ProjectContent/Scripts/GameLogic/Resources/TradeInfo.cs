using System.Collections.Generic;

namespace WhiteTeam.GameLogic.Resources
{
    public class TradeInfo
    {
        private readonly Dictionary<Resource.CurrencyProducts, bool> _info =
            new Dictionary<Resource.CurrencyProducts, bool>
            {
                // RawMaterial
                {Resource.CurrencyProducts.WOOD, true},
                {Resource.CurrencyProducts.ORE, true},
                {Resource.CurrencyProducts.CLAY, true},
                {Resource.CurrencyProducts.STONE, true},

                // Products
                {Resource.CurrencyProducts.PAPYRUS, true},
                {Resource.CurrencyProducts.CLOTH, true},
                {Resource.CurrencyProducts.GLASS, true},
            };

        public bool Check(Resource.CurrencyProducts currency) => _info[currency];

        public void Lock(Resource.CurrencyProducts currency) => _info[currency] = false;

        public void Reset()
        {
            foreach (var currencyKey in _info.Keys)
            {
                _info[currencyKey] = true;
            }
        }
    }
}