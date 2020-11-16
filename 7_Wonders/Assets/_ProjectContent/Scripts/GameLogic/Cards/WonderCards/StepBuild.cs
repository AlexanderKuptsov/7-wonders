using System.Linq;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public abstract class StepBuild
    {
        public readonly Resource.CurrencyItem[] CostInfo;

        public bool IsCompleted { get; private set; }

        public StepBuild(Resource.CurrencyItem[] costInfo)
        {
            CostInfo = costInfo;
        }

        public bool CanBuild(PlayerData player)
        {
            // Check player for card activation requirement resources
            var haveEnoughResources =
                CostInfo.All(currencyItem => player.Resources.HasEnoughCurrency(currencyItem));
            return haveEnoughResources;
        }

        public void Build(PlayerData player)
        {
            Buy(player);
            Activate(player);
            Complete();
        }

        private void Complete()
        {
            IsCompleted = true;
        }

        private void Buy(PlayerData player)
        {
            foreach (var currencyItem in CostInfo)
            {
                player.Resources.SpendProduction(currencyItem);
            }
        }

        protected abstract void Activate(PlayerData player);
    }
}