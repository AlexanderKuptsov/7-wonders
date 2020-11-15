using System.Linq;
using MyBox;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class WonderCard //: CardData // TODO
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;

        private StepBuild[] _stepBuilds;

        private int _completedSteps;

        public StepBuild CurrentStepBuild => _completedSteps < _stepBuilds.Length ? _stepBuilds[_completedSteps] : null;

        public bool IsCompleted => _stepBuilds.All(build => build.IsCompleted);

        public WonderCard(string id, string name, StepBuild[] stepBuilds)
        {
            Id = id;
            Name = name;
            _stepBuilds = stepBuilds;
            _completedSteps = 0;
        }

        public void Build(PlayerData player, Card cardToThrow)
        {
            player.ThrowCard(cardToThrow);
            var currentStepBuild = CurrentStepBuild;
            NextBuild(player, currentStepBuild);
            CompleteStep(currentStepBuild);
        }

        private void CompleteStep(StepBuild stepBuild)
        {
            stepBuild.Complete();
            _completedSteps++;
        }

        protected abstract void NextBuild(PlayerData player, StepBuild stepBuild);
        public abstract void ActivateStartGameEffect(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public class StepBuild // TODO
        {
            [ReadOnly] public Resource.CurrencyItem[] CostInfo;

            public bool IsCompleted { get; private set; }

            public StepBuild(Resource.CurrencyItem[] costInfo)
            {
                CostInfo = costInfo;
            }

            public void Complete()
            {
                IsCompleted = true;
            }
        }
    }
}