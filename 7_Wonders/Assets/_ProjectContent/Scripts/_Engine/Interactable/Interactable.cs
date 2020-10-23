using UnityEngine;

namespace SK_Engine
{
    public class Interactable : MonoBehaviour
    {
        public bool isFocused { get; private set; }
        public bool isStopped { get; private set; }


        private void Awake()
        {
            Setup();
            EventsSubscriptions();
        }

        private void OnDisable()
        {
            EventsDescriptions();
        }

        protected virtual void Setup()
        {
            isFocused = false;
            isStopped = false;
        }

        protected virtual void EventsSubscriptions()
        {
            EventHandler.OnTimeScaleChanged += CheckTimeScale;
        }

        protected virtual void EventsDescriptions()
        {
            EventHandler.OnTimeScaleChanged -= CheckTimeScale;
        }

        protected virtual void CheckTimeScale(bool _stop)
        {
            isStopped = _stop;
        }

        protected virtual void Interact()
        {
            Debug.Log("Interacting");
        }

        private void OnMouseDown()
        {
            if (!isStopped)
                OnMouseDownAction();
        }

        protected virtual void OnMouseUp()
        {
            if (!isStopped)
                OnMouseUpAction();
        }

        protected void OnMouseEnter()
        {
            if (!isStopped)
                OnMouseEnterAction();
        }

        protected void OnMouseExit()
        {
            if (!isStopped)
                OnMouseExitAction();
        }

        protected virtual void OnMouseDownAction()
        {
        }

        protected virtual void OnMouseUpAction()
        {
            if (isFocused)
                Interact();
        }

        protected virtual void OnMouseEnterAction()
        {
            isFocused = true;
        }

        protected virtual void OnMouseExitAction()
        {
            isFocused = false;
        }
    }
}