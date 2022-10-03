using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public static event Action<Objective, Rule> OnObjectiveDeclared;
		public static event Action OnGameWin;
		public static event Action OnGameLose;

	    Objective[] objectivePool;
		Rule[] rulePool;

		Objective currentObjective;
		Rule currentRule;
		bool checkingObjective = true;

		void Start()
		{
			//currentObjective = new DeathmatchObjective();
			//currentRules.Add(new OnePlayerLifeRule());
			currentObjective = new TreasureHuntObjective();
			currentObjective.Setup();
			currentRule = new TimerRule(5f);
			OnObjectiveDeclared?.Invoke(currentObjective, currentRule);
		}

		void Update()
		{
			if (checkingObjective && currentObjective.Completed())
			{
				checkingObjective = false;
				WinGame();
			}
			if (currentRule == null)
			{
				return;
			}
			if (checkingObjective)
			{

				if (currentRule.Broken())
				{
					checkingObjective = false;
					LoseGame();
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

