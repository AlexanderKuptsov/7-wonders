using MyBox;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class RulesParameters : Singleton<RulesParameters>
    {
        public PlayerDirection FirstSwipeDirection = PlayerDirection.LEFT;
        [PositiveValueOnly] public int CardExchangeAmount = 3;
        [PositiveValueOnly] public int ResourceDefaultBuyCost = 2;
    }
}