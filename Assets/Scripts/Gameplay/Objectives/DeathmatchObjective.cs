using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
	public class DeathmatchObjective : Objective
	{
		List<BotHealth> allBots = new List<BotHealth>();
		bool finishedSpawning = false;

		public DeathmatchObjective()
		{
			Description = "Deathmatch: Destroy all bot enemies to win.";
			EnemySpawner.OnFinishedSpawning += FinishedSpawning;
		}

		public override void Setup()
		{
			EnemySpawner.GlobalSpawnEnemies(2, 30f);
		}

		public override bool Completed()
		{
			if (!finishedSpawning)
			{
				return false;
			}
			for (int i = 0; i < allBots.Count; i++)
			{
				if (allBots[i].CurrentHealth > 0)
				{
					return false;
				}
			}
			return true;
		}

		void FinishedSpawning()
		{
			if (finishedSpawning == false)
			{
				finishedSpawning = true;
				allBots = GameObject.FindObjectsOfType<BotHealth>().ToList();
			}
		}

		~DeathmatchObjective()
		{
			EnemySpawner.OnFinishedSpawning -= FinishedSpawning;
		}
	}
}

