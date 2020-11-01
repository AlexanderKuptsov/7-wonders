using MyBox;
using SK_Engine;
using UnityEngine;

namespace WhiteTeam.GameLogic
{
    public class Timer : MonoBehaviour
    {
        [ReadOnly] public float RemainingTime;

        public readonly EventHolderBase OnTimerEnd = new EventHolderBase();

        public bool IsWorking { get; private set; } = false;

        private void Update()
        {
            if (!IsWorking) return;
            RemainingTime -= Time.deltaTime;

            if (RemainingTime < 0)
            {
                End();
            }
        }

        public void Setup(float targetTime)
        {
            RemainingTime = targetTime;
            IsWorking = true;
        }

        private void End()
        {
            IsWorking = false;
            OnTimerEnd.TriggerEvents();
        }
    }
}