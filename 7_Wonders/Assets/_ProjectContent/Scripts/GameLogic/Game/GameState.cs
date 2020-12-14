namespace WhiteTeam.GameLogic
{
    public class GameState
    {
        public EpochType Epoch { get; private set; } = EpochType.FIRST;
        public int Move { get; private set; } = 1;

        public bool IsEpochStart => Move == 1;
        public bool IsCompleted => Epoch == EpochType.COMPLETED;

        public void NextMove()
        {
            Move = Move == 6 ? 1 : Move + 1;
            if (Move == 1)
            {
                NextEpoch();
            }
        }

        private void NextEpoch()
        {
            Epoch = (EpochType) (int) Epoch++;
        }

        public enum EpochType
        {
            FIRST = 1,
            SECOND = 2,
            THIRD = 3,
            COMPLETED = 4
        }
    }
}