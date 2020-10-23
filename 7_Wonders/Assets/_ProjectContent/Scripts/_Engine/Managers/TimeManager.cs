using System;
using UnityEngine;

namespace SK_Engine
{
	public class TimeManager : Singleton<TimeManager>
	{
		public TimeMode Mode { get; private set; }
		
		[SerializeField] private TimeMode startMode = TimeMode.X1;

		private TimeMode lastMode;

		public override void Awake()
		{
			base.Awake();
			SetTimeMode(startMode);
			lastMode = Mode;
		}

		public void SetTimeMode(TimeMode _mode)
		{
			switch (_mode)
			{
				case TimeMode.PAUSE:
					Time.timeScale = 0f;
					break;
				case TimeMode.X0_5:
					Time.timeScale = 0.5f;
					break;
				case TimeMode.X1:
					Time.timeScale = 1f;
					break;
				case TimeMode.X2:
					Time.timeScale = 2f;
					break;
				case TimeMode.X4:
					Time.timeScale = 4f;
					break;
			}
			Debug.Log("Time scale changed to " + Time.timeScale);
			Mode = _mode;
			EventHandler.TimeScaleChange(Time.timeScale);
		}

		public void SpeedUp()
		{
			switch (Mode)
			{
				case TimeMode.X0_5:
					SetTimeMode(TimeMode.X1);
					break;
				case TimeMode.X1:
					SetTimeMode(TimeMode.X2);
					break;
				case TimeMode.X2:
					SetTimeMode(TimeMode.X4);
					break;
				case TimeMode.X4:
					break;
				case TimeMode.PAUSE:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void SpeedUpLoop()
		{
			switch (Mode)
			{
				case TimeMode.X0_5:
					SetTimeMode(TimeMode.X1);
					break;
				case TimeMode.X1:
					SetTimeMode(TimeMode.X2);
					break;
				case TimeMode.X2:
					SetTimeMode(TimeMode.X4);
					break;
				case TimeMode.X4:
					SetTimeMode(TimeMode.X0_5);
					break;
				case TimeMode.PAUSE:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Pause()
		{
			lastMode = Mode;
			SetTimeMode(TimeMode.PAUSE);
		}

		public void Resume()
		{
			SetTimeMode(lastMode);
		}
	}

	public enum TimeMode
	{
		PAUSE,
		X0_5,
		X1,
		X2,
		X4
	}
}