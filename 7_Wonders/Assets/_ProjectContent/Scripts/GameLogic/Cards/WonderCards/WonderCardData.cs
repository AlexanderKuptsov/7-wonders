using System.Linq;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards.Wonder
{
    public abstract class WonderCardData : CardData
    {
        public Resource.CurrencyItem StartCurrencyEffect { get; private set; }
        
        protected StepBuild[] StepBuilds;
        private int _completedSteps;

        public StepBuild CurrentStepBuild => _completedSteps < StepBuilds.Length ? StepBuilds[_completedSteps] : null;

        public bool IsCompleted => StepBuilds.All(build => build.IsCompleted);

        public WonderCardData(string id, string name, Resource.CurrencyItem startCurrencyItem) : base(id, name)
        {
            StartCurrencyEffect = startCurrencyItem;
            _completedSteps = 0;
        }

        public bool CanBuildCurrentStep(PlayerData player)
        {
            var currentStepBuild = CurrentStepBuild;
            return currentStepBuild != null && currentStepBuild.CanBuild(player);
        }

        public void Build(PlayerData player, CommonCard cardToThrow)
        {
            player.ThrowCard(cardToThrow);
            var currentStepBuild = CurrentStepBuild;
            currentStepBuild.Build(player);
            _completedSteps++;
        }

        public override void Use(PlayerData player)
        {
        }

        public override void ActivatedUse(PlayerData player)
        {
        }

        public virtual void ActivateStartGameEffect(PlayerData player)
        {
        }

        public override void ActivateEndGameEffect(PlayerData player)
        {
        }
    }
}