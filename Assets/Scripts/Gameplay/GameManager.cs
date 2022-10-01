using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public static event Action OnGameWin;
		public static event Action OnGameLose;

	    Objective[] objectivePool;

		Objective currentObjective;
		bool checkingObjective = true;

		void Awake()
		{
			BotController[] botControllers = FindObjectsOfType<BotController>();
			List<GameObject> allBots = new List<GameObject>();
			foreach (var bot in botControllers)
			{
				allBots.Add(bot.gameObject);
			}
			currentObjective = new DeathmatchObjective(allBots);
		}

		void Update()
		{
			if (checkingObjective && currentObjective.Completed())
			{
				checkingObjective = false;
				WinGame();
			}
			if (checkingObjective && currentObjective.Failed())
			{
				checkingObjective = false;
				LoseGame();
			}
		}

		void WinGame()
		{
			print("You win!!");
			OnGameWin?.Invoke();
		}

		void LoseGame()
		{

		}
	}
}

