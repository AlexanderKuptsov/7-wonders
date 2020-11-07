using System;

namespace WhiteTeam.GameLogic.Resources
{
    [Serializable]
    public struct PlayerResources
    {
        public Resource Money;
        public Resource Science;
        public Resource War;
        public Resource Victory;
        public Resource Conflict;

        // TODO
        public Resource IncomeResources;
        public Resource IncomeProducts;
    }
}