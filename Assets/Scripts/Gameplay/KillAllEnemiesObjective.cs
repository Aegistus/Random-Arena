using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class KillAllEnemiesObjective : Objective
	{
		List<GameObject> allBots = new List<GameObject>();

		public KillAllEnemiesObjective(List<GameObject> bots)
		{
			allBots = bots;
		}

		public override bool Completed()
		{
			for (int i = 0; i < allBots.Count; i++)
			{
				if (allBots[i].activeInHierarchy)
				{
					return false;
				}
			}
			return true;
		}

		public override bool Failed()
		{
			return false;
		}
	}
}

