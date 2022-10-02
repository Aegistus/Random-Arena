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
		Rule[] rulePool;

		Objective currentObjective;
		List<Rule> currentRules = new List<Rule>();
		bool checkingObjective = true;

		void Start()
		{
			//currentObjective = new DeathmatchObjective();
			//currentRules.Add(new OnePlayerLifeRule());
			currentObjective = new TreasureHuntObjective();
			currentObjective.Setup();
		}

		void Update()
		{
			if (checkingObjective && currentObjective.Completed())
			{
				checkingObjective = false;
				WinGame();
			}
			if (checkingObjective)
			{
				for (int i = 0; i < currentRules.Count; i++)
				{
					if (currentRules[i].Broken())
					{
						checkingObjective = false;
						LoseGame();
					}
				}
			}

		}

		void WinGame()
		{
			OnGameWin?.Invoke();
		}

		void LoseGame()
		{
			OnGameLose?.Invoke();
		}
	}
}

