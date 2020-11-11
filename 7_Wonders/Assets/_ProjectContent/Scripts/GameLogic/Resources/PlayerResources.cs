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

        private Dictionary<Resource.Currency, int> _science = new Dictionary<Resource.Currency, int>
        {
            {Resource.Currency.RUNE_1, START_RESOURCE_AMOUNT},
            {Resource.Currency.RUNE_2, START_RESOURCE_AMOUNT},
            {Resource.Currency.RUNE_3, START_RESOURCE_AMOUNT},
        };

        private Dictionary<Resource.Currency, int> _production = new Dictionary<Resource.Currency, int>
        {
            // RawMaterial
            {Resource.Currency.WOOD, START_RESOURCE_AMOUNT},
            {Resource.Currency.ORE, START_RESOURCE_AMOUNT},
            {Resource.Currency.CLAY, START_RESOURCE_AMOUNT},
            {Resource.Currency.STONE, START_RESOURCE_AMOUNT},

            // Products
            {Resource.Currency.PAPYRUS, START_RESOURCE_AMOUNT},
            {Resource.Currency.CLOTH, START_RESOURCE_AMOUNT},
            {Resource.Currency.GLASS, START_RESOURCE_AMOUNT},
        };

        // ----- TEMP -----
        private Resource _tempMoney = new Resource();

        private Dictionary<Resource.Currency, int> _tempProduction = new Dictionary<Resource.Currency, int>
        {
            // RawMaterial
            {Resource.Currency.WOOD, START_RESOURCE_AMOUNT},
            {Resource.Currency.ORE, START_RESOURCE_AMOUNT},
            {Resource.Currency.CLAY, START_RESOURCE_AMOUNT},
            {Resource.Currency.STONE, START_RESOURCE_AMOUNT},

            // Products
            {Resource.Currency.PAPYRUS, START_RESOURCE_AMOUNT},
            {Resource.Currency.CLOTH, START_RESOURCE_AMOUNT},
            {Resource.Currency.GLASS, START_RESOURCE_AMOUNT},
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

        public void AddProduction(Resource.CurrencyItem newProduction)
        {
            _production[newProduction.Currency] += newProduction.Amount;
        }

        public void AddScience(Resource.CurrencyItem newScience)
        {
            _production[newScience.Currency] += newScience.Amount;
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

        public int GetProduction(Resource.Currency currency)
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

        public int GetScience(Resource.Currency currency)
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

        private void ResetProduction(Dictionary<Resource.Currency, int> production)
        {
            foreach (var currency in production.Keys)
            {
                production[currency] = START_RESOURCE_AMOUNT;
            }
        }

        #endregion
    }
}