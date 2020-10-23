namespace SK_Engine
{
    public class EventHolderBase
    {
        public delegate void EventHandler();

        public event EventHandler OnEventTriggered;

        public void TriggerEvents()
        {
            OnEventTriggered?.Invoke();
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