using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class MainMenuUI : MonoBehaviour
	{
	    [SerializeField] string gameSceneName;

		public void StartGame()
		{
			SceneManager.LoadScene(gameSceneName);
		}
	}
}

