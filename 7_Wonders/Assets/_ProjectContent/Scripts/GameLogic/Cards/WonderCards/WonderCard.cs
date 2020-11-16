using System.Linq;
using MyBox;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public abstract class WonderCard //: CardData // TODO
    {
        [ReadOnly] public string Id;
        [ReadOnly] public string Name;

        protected StepBuild[] stepBuilds;

        private int _completedSteps;

        public StepBuild CurrentStepBuild => _completedSteps < stepBuilds.Length ? stepBuilds[_completedSteps] : null;

        public bool IsCompleted => stepBuilds.All(build => build.IsCompleted);

        public WonderCard(string id, string name)
        {
            Id = id;
            Name = name;
            _completedSteps = 0;
        }

        public bool CanBuildCurrentStep(PlayerData player)
        {
            var currentStepBuild = CurrentStepBuild;
            return currentStepBuild != null && currentStepBuild.CanBuild(player);
        }

        public void Build(PlayerData player, Card cardToThrow)
        {
            player.ThrowCard(cardToThrow);
            var currentStepBuild = CurrentStepBuild;
            NextBuild(player, currentStepBuild);
            _completedSteps++;
        }

        private static void NextBuild(PlayerData player, StepBuild stepBuild)
        {
            stepBuild.Build(player);
        }

        public virtual void ActivateStartGameEffect(PlayerData player)
        {
        }

        public virtual void ActivateEndGameEffect(PlayerData player)
        {
        }
    }
}