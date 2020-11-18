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

        private Resource _military = new Resource(GameParameters.Instance.DefaultResources.Military);
        private Resource _victory = new Resource(GameParameters.Instance.DefaultResources.Victory);

        private Resource _warVictoryTokens = new Resource(GameParameters.Instance.DefaultResources.WarLoseTokens);
        public Resource _warLoseTokens = new Resource(GameParameters.Instance.DefaultResources.WarLoseTokens);

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

        // SPECIAL
        private Resource _freeBuildTokens = new Resource(GameParameters.Instance.DefaultResources.FreeBuildTokens);

        // ----- TEMP -----
        private Resource _tempMoney = new Resource();

        private Dictionary<Resource.CurrencyProducts, int> _tempProduction =
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

        private const int START_RESOURCE_AMOUNT = 0;

        public bool HasEnoughCurrency(Resource.CurrencyItem currencyItem)
        {
            var requiredCurrencyType = currencyItem.Currency;
            var requiredCurrencyAmount = currencyItem.Amount;
            var currencyAmount = requiredCurrencyType == Resource.CurrencyProducts.MONEY
                ? GetMoney()
                : GetProduction(requiredCurrencyType);

            return currencyAmount >= requiredCurrencyAmount;
        }

        public void Buy(Resource.CurrencyItem currencyItem)
        {
            var requiredCurrencyType = currencyItem.Currency;
            var requiredCurrencyAmount = currencyItem.Amount;
            if (requiredCurrencyType == Resource.CurrencyProducts.MONEY)
            {
                _money.Decrease(requiredCurrencyAmount);
            }
            else
            {
                _production[requiredCurrencyType] -= requiredCurrencyAmount;
            }
        }

        public void ConvertWarTokensToVictory()
        {
            var warProfit = GetWarVictoryTokens() - GetWarLoseTokens();
            ChangeVictory(warProfit);
        }

        #region CHANGE

        public void ChangeMoney(int amount)
        {
            _money.Increase(amount);
        }

        public void ChangeMilitary(int amount)
        {
            _military.Increase(amount);
        }

        public void ChangeVictory(int amount)
        {
            _victory.Increase(amount);
        }

        public void ChangeWarVictoryTokens(int amount)
        {
            _warVictoryTokens.Increase(amount);
        }

        public void ChangeWarLoseTokens(int amount)
        {
            _warLoseTokens.Increase(amount);
        }

        public void ChangeProduction(Resource.CurrencyItem newProduction)
        {
            _production[newProduction.Currency] += newProduction.Amount;
        }

        public void SpendProduction(Resource.CurrencyItem newProduction)
        {
            _production[newProduction.Currency] -= newProduction.Amount;
        }

        public void AddScience(Resource.ScienceItem newScience)
        {
            _science[newScience.Currency] += newScience.Amount;
        }

        public void ChangeFreeBuildTokens(int amount)
        {
            _freeBuildTokens.Increase(amount);
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

        public int GetWarVictoryTokens()
        {
            return _warVictoryTokens.Value;
        }

        public int GetWarLoseTokens()
        {
            return _warLoseTokens.Value;
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

        public int GetFreeBuildTokens()
        {
            return _freeBuildTokens.Value;
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
            ChangeMoney(_tempMoney.Value);
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