using MyBox;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class RulesParameters : Singleton<RulesParameters>
    {
        public GameSession.SwipeDirection FirstSwipeDirection = GameSession.SwipeDirection.LEFT;
        [PositiveValueOnly] public int CardExchangeAmount = 3;
    }
}