using System;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.GlobalParameters;

namespace WhiteTeam.GameLogic.Resources
{
    [Serializable]
    public class PlayerResources
    {
        // ----- MAIN -----
        private Resource _money = new Resource(GameParameters.Instance.DefaultResources.Money);

        public Resource _military = new Resource(GameParameters.Instance.DefaultResources.War);
        public Resource _victory = new Resource(GameParameters.Instance.DefaultResources.Victory);
        public Resource _loseTokens = new Resource(GameParameters.Instance.DefaultResources.LoseTokens);

        private Dictionary<Resource.Science, int> _science = new Dictionary<Resource.Science, int>
        {
            {Resource.Science.RUNE_1, START_RESOURCE_AMOUNT},
            {Resource.Science.RUNE_2, START_RESOURCE_AMOUNT},
            {Resource.Science.RUNE_3, START_RESOURCE_AMOUNT},
        };

        private Dictionary<Resource.CurrencyProducts, int> _production = new Dictionary<Resource.CurrencyProducts, int>
        {
            // RawMaterial
            {Resource.CurrencyProducts.WOOD, START_RESOURCE_AMOUNT},
            {Resource.CurrencyProducts.ORE, START_RESOURCE_AMOUNT},
            {Resource.CurrencyProducts.CLAY, START_RESOURCE_AMOUNT},
            {Resource.CurrencyProducts.STONE, START_RESOURCE_AMOUNT},

            // Products
            {Resource.CurrencyProducts.GLASS, START_RESOURCE_AMOUNT},
        };

        // ----- TEMP -----
        private Resource _tempMoney = new Resource();

        private Dictionary<Resource.CurrencyProducts, int> _tempProduction = new Dictionary<Resource.CurrencyProducts, int>
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

        private const int START_RESOURCE_AMOUNT = 0;

        #region ADDITION

        public void AddMoney(int amount)
        {
            _money.Increase(amount);
        }

        public void AddMilitary(int amount)
        {
            _military.Increase(amount);
        }

        public void AddVictory(int amount)
        {
            _victory.Increase(amount);
        }
        
        public void AddLoseTokens(int amount)
        {
            _loseTokens.Increase(amount);
        }

        public void AddProduction(Resource.CurrencyItem newProduction)
        {
            _production[newProduction.Currency] += newProduction.Amount;
        }

        public void AddScience(Resource.ScienceItem newScience)
        {
            _science[newScience.Currency] += newScience.Amount;
        }

        #endregion

        #region GETTERS

        public int GetMoney()
        {
            return _money.Value;
        }

        public int GetMilitary()
        {
            return _military.Value;
        }

        public int GetVictory()
        {
            return _victory.Value;
        }
        
        public int GetLoseTokens()
        {
            return _loseTokens.Value;
        }

        public int GetProduction(Resource.CurrencyProducts currency)
        {
            var amount = START_RESOURCE_AMOUNT;

            if (!_production.ContainsKey(currency) || !_tempProduction.ContainsKey(currency))
            {
                Debug.LogError("[PlayerResources] Invalid currency access");
                return amount;
            }

            amount += _production[currency];
            amount += _tempProduction[currency];

            return amount;
        }

        public int GetScience(Resource.Science currency)
        {
            if (!_science.ContainsKey(currency))
            {
                Debug.LogError("[PlayerResources] Invalid currency access");
                return START_RESOURCE_AMOUNT;
            }

            return _science[currency];
        }

        #endregion

        #region TEMP RESOURCES

        public void EarnTempMoney(int amount)
        {
            _tempMoney.Increase(amount);
        }

        public void EarnTempProduction(Resource.CurrencyItem newProduction)
        {
            _tempProduction[newProduction.Currency] += newProduction.Amount;
        }

        public void HandleTemp()
        {
            // MONEY
            AddMoney(_tempMoney.Value);
            _tempMoney.Clear();

            // PRODUCTION
            ResetProduction(_tempProduction);
        }

        #endregion

        #region METHODS

        private void ResetProduction(Dictionary<Resource.CurrencyProducts, int> production)
        {
            foreach (var currency in production.Keys)
            {
                production[currency] = START_RESOURCE_AMOUNT;
            }
        }

        #endregion
    }
}