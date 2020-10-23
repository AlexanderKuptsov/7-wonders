
using UnityEngine;

namespace SK_Engine
{
	public class HideShowUI : MonoBehaviour
	{
		[Tooltip("Show UI elements on start")] 
		public bool isShownOnStart = false;
		[HideInInspector] public bool isShown;

		private Animator animator;

		void Start()
		{
			animator = GetComponent<Animator>();
			animator.updateMode = AnimatorUpdateMode.UnscaledTime;
			isShown = false;
			Setup();
		}

		void OnEnable()
		{
			EventsSubscriptions();
		}

		private void OnDisable()
		{
			EventsDescriptions();
		}

		protected virtual void Setup()
		{
			if (isShownOnStart)
				ShowOrHide(true);
			else
			{
				/*animator.SetInteger("direction", 1);
				animator.SetInteger("direction", -1);
				isShown = false;*/
			}
		}

		protected virtual void EventsSubscriptions()
		{
			EventHandler.OnTimeScaleChanged += CheckTimeScale;
		}

		protected virtual void EventsDescriptions()
		{
			EventHandler.OnTimeScaleChanged -= CheckTimeScale;
		}

		protected virtual void CheckTimeScale(bool stop)
		{
			if (isShown == !stop) return;
			animator.SetInteger("direction", stop ? -1 : 1);
			isShown = !stop;
		}

		protected virtual void ShowOrHide(bool show)
		{
			if (isShown == show) return;
			animator.SetInteger("direction", show ? 1 : -1);
			isShown = show;
		}
	}
}