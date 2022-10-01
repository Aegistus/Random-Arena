using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class LoseScreenUI : MonoBehaviour
	{
		[SerializeField] GameObject panel;

		void Start()
		{
			panel.SetActive(false);
			GameManager.OnGameLose += DisplayScreen;
		}

		void DisplayScreen()
		{
			panel.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}

