using System;
using System.Collections.Generic;
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
            {Resource.Science.RUNE_1, GameParameters.Instance.DefaultResources.Science},
            {Resource.Science.RUNE_2, GameParameters.Instance.DefaultResources.Science},
            {Resource.Science.RUNE_3, GameParameters.Instance.DefaultResources.Science},
        };

        private ProductionResources _production = new ProductionResources();

        // SPECIAL
        private Resource _freeBuildTokens = new Resource(GameParameters.Instance.DefaultResources.FreeBuildTokens);

        // ----- TEMP -----
        private Resource _tempMoney = new Resource();

        private ProductionResources _tempProduction = new ProductionResources();

        // NO TRADE
        private ProductionResources _noTradeProduction = new ProductionResources();


        public bool HasEnoughCurrency(Resource.CurrencyItem currencyItem)
        {
            var requiredCurrencyType = currencyItem.Currency;
            var requiredCurrencyAmount = currencyItem.Amount;
            var currencyAmount = requiredCurrencyType == Resource.CurrencyProducts.MONEY
                ? GetMoney()
                : GetSelfProduction(requiredCurrencyType);

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
                _production.Storage[requiredCurrencyType] -= requiredCurrencyAmount;
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

        public void AddProduction(Resource.CurrencyItem newProduction)
        {
            _production.Storage[newProduction.Currency] += newProduction.Amount;
        }

        public void SpendProduction(Resource.CurrencyItem newProduction)
        {
            _production.Storage[newProduction.Currency] -= newProduction.Amount;
        }

        public void AddScience(Resource.ScienceItem newScience)
        {
            _science[newScience.Currency] += newScience.Amount;
        }

        public void SpendScience(Resource.ScienceItem newScience)
        {
            _science[newScience.Currency] -= newScience.Amount;
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

        public int GetSelfProduction(Resource.CurrencyProducts currency)
        {
            var amount = 0;

            amount += _production.Storage[currency];
            amount += _tempProduction.Storage[currency];
            amount += _noTradeProduction.Storage[currency];

            return amount;
        }

        public int GetTradeProduction(Resource.CurrencyProducts currency)
        {
            return _production.Storage[currency];
        }


        public int GetScience(Resource.Science currency)
        {
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
            _tempProduction.Storage[newProduction.Currency] += newProduction.Amount;
        }

        public void HandleTemp()
        {
            // MONEY
            ChangeMoney(_tempMoney.Value);
            _tempMoney.Clear();

            // PRODUCTION
            _tempProduction.Reset();
        }

        #endregion

        #region NO TRADE

        public void EarnNoTradeProduction(Resource.CurrencyItem newProduction)
        {
            _noTradeProduction.Storage[newProduction.Currency] += newProduction.Amount;
        }

        public void RemoveNoTradeProduction(Resource.CurrencyItem newProduction)
        {
            _noTradeProduction.Storage[newProduction.Currency] -= newProduction.Amount;
        }

        #endregion

        public OutputResources GetCurrentResourcesState()
            => new OutputResources
            {
                Money = GetMoney(),
                Military = GetMilitary(),
                Victory = GetVictory(),
                WarVictoryTokens = GetWarVictoryTokens(),
                WarLoseTokens = GetWarLoseTokens(),
                Rune1 = GetScience(Resource.Science.RUNE_1),
                Rune2 = GetScience(Resource.Science.RUNE_2),
                Rune3 = GetScience(Resource.Science.RUNE_3),

                Wood = GetTradeProduction(Resource.CurrencyProducts.WOOD),
                Ore = GetTradeProduction(Resource.CurrencyProducts.ORE),
                Clay = GetTradeProduction(Resource.CurrencyProducts.CLAY),
                Stone = GetTradeProduction(Resource.CurrencyProducts.STONE),
                Papyrus = GetTradeProduction(Resource.CurrencyProducts.PAPYRUS),
                Cloth = GetTradeProduction(Resource.CurrencyProducts.CLOTH),
                Glass = GetTradeProduction(Resource.CurrencyProducts.GLASS),
            };

        public OutputResources GetSelfCurrentResourcesState()
            => new OutputResources
            {
                Money = GetMoney(),
                Military = GetMilitary(),
                Victory = GetVictory(),
                WarVictoryTokens = GetWarVictoryTokens(),
                WarLoseTokens = GetWarLoseTokens(),
                Rune1 = GetScience(Resource.Science.RUNE_1),
                Rune2 = GetScience(Resource.Science.RUNE_2),
                Rune3 = GetScience(Resource.Science.RUNE_3),

                Wood = GetSelfProduction(Resource.CurrencyProducts.WOOD),
                Ore = GetSelfProduction(Resource.CurrencyProducts.ORE),
                Clay = GetSelfProduction(Resource.CurrencyProducts.CLAY),
                Stone = GetSelfProduction(Resource.CurrencyProducts.STONE),
                Papyrus = GetSelfProduction(Resource.CurrencyProducts.PAPYRUS),
                Cloth = GetSelfProduction(Resource.CurrencyProducts.CLOTH),
                Glass = GetSelfProduction(Resource.CurrencyProducts.GLASS),
            };
    }
}