using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public static event Action<Objective, Rule> OnObjectiveDeclared;
		public static event Action OnGameWin;
		public static event Action OnGameLose;

		[SerializeField] float objectiveStartDelay = 3f;

	    Objective[] objectivePool;
		Rule[] rulePool;

		Objective currentObjective;
		Rule currentRule;
		bool checkingObjective = false;

		void Start()
		{
			objectivePool = new Objective[]
			{
				new DeathmatchObjective(),
				new TreasureHuntObjective(),
				new RaceObjective()
			};
			rulePool = new Rule[]
			{
				new TimerRule(120f),
				new OnePlayerLifeRule(),
			};
			StartCoroutine(DeclareRuleAndObjective());
		}

		IEnumerator DeclareRuleAndObjective()
		{
			yield return new WaitForSeconds(objectiveStartDelay);
			currentObjective = objectivePool[Random.Range(0, objectivePool.Length)];
			currentObjective.Setup();

			currentRule = rulePool[Random.Range(0, rulePool.Length)];
			currentRule.Activate();
			OnObjectiveDeclared?.Invoke(currentObjective, currentRule);
			checkingObjective = true;
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

