namespace SK_Engine
{
    public class EventHolder<T>    // TODO - merge with base
    {
        public delegate void EventHandler(T _value);

        public event EventHandler OnEventTriggered;

        public void TriggerEvents(T _value)
        {
            OnEventTriggered?.Invoke(_value);
        }

        public void Subscribe(EventHandler _listener)
        {
            OnEventTriggered += _listener;
        }

        public void Unsubscribe(EventHandler _listener)
        {
            OnEventTriggered -= _listener;
        }

        public void UnSubscribeAllEvents()    // TODO - check it
        {
            if (OnEventTriggered == null) return;
            for (var index = OnEventTriggered.GetInvocationList().Length - 1; index >= 0; index--)
            {
                OnEventTriggered -= OnEventTriggered?.GetInvocationList()[index] as EventHandler;
            }
        }
    }
}