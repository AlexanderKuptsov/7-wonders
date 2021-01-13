using MyBox;
using UnityEngine;
using WhiteTeam.GameLogic.Utils;

public class TimerTest : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void Start()
    {
        SetupTimer();
    }

    private void SetupTimer()
    {
        timer.Setup(Random.Range(2f, 8f));
    }

#if UNITY_EDITOR
    [ButtonMethod]
    private string ResetTimer()
    {
        SetupTimer();
        return $"Timer reset to ({timer.RemainingTime})";
    }
#endif
}