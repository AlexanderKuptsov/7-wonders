using UnityEngine;
using UnityEngine.Events;

namespace SK_Engine
{
    public class BoolTriggerUnityEvent : BoolTriggerEvent
    {
        [Header("Events")]
        public UnityEvent onValueChangedEvent;
        public UnityEvent onTrueValueSetEvent;
        public UnityEvent onFalseValueSetEvent;

        protected override void AdditionalEvents(bool _value)
        {
            onValueChangedEvent?.Invoke();
            base.AdditionalEvents(_value);
        }

        protected override void TrueValueSet()
        {
            base.TrueValueSet();
            onTrueValueSetEvent?.Invoke();
        }

        protected override void FalseValueSet()
        {
            base.FalseValueSet();
            onFalseValueSetEvent?.Invoke();
        }
        
        // ----- API -----
        public void UnSubscribeFromAllUnityEvents()
        {
            onValueChangedEvent?.RemoveAllListeners();
            onTrueValueSetEvent?.RemoveAllListeners();
            onFalseValueSetEvent?.RemoveAllListeners();
        }
        
        // TODO clear all events
    }
}