using UnityEngine;

namespace SK_Engine
{
    public class EventHandler : MonoBehaviour
    {
        // Time management
        public delegate void TimeScaleHandler(bool _isStopped);

        public static event TimeScaleHandler OnTimeScaleChanged;

        // Start events
        public delegate void StartHandler();

        public static event StartHandler OnStart;

        // Floating _text events
        public delegate void FloatingTextHandler(string _text, Vector3 _location);

        public static event FloatingTextHandler OnFloatingTextCreation;


        public static void TimeScaleChange(float _timeScale)
        {
            OnTimeScaleChanged?.Invoke(_timeScale == 0);
        }

        public static void StartEvent()
        {
            OnStart?.Invoke();
        }

        public static void FloatingTextCreation(string _text, Vector3 _location)
        {
            OnFloatingTextCreation?.Invoke(_text, _location);
        }
    }
}