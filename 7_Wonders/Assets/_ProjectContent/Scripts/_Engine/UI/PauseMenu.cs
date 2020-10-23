using UnityEngine;
using UnityEngine.SceneManagement;

namespace SK_Engine
{
	public class PauseMenu : MonoBehaviour
	{

		public static bool isPaused = false;
		public GameObject PauseMenuUI;
		public GameObject OptionsMenu;

		// Update is called once per frame
		void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Escape) || OptionsMenu.activeSelf) return;
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

		public void Resume()
		{
			PauseMenuUI.SetActive(false);
			Time.timeScale = 1f;
			isPaused = false;
			EventHandler.TimeScaleChange(Time.timeScale);
		}

		void Pause()
		{
			PauseMenuUI.SetActive(true);
			Time.timeScale = 0f;
			isPaused = true;
			EventHandler.TimeScaleChange(Time.timeScale);
		}

		public void loadOptions()
		{

		}

		public void loadMenu()
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene("Menu");
		}
	}
}