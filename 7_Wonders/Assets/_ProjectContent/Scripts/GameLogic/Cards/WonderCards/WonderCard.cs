using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class WonderCard //: CardData // TODO
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;

        private StepBuild[] _stepBuilds;

        public WonderCard(string id, string name, StepBuild[] stepBuilds)
        {
            Id = id;
            Name = name;
            _stepBuilds = stepBuilds;
        }

        public void Build(PlayerData player, Card cardToThrow)
        {
            player.ThrowCard(cardToThrow);
            NextBuild(player);
        }

        protected abstract void NextBuild(PlayerData player);
        public abstract void ActivateStartGameEffect(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public class StepBuild // TODO
        {
            [ReadOnly] public Resource.CurrencyItem[] CostInfo;

            public StepBuild(Resource.CurrencyItem[] costInfo)
            {
                CostInfo = costInfo;
            }
        }
    }
}