using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class DeathmatchObjective : Objective
	{
		List<GameObject> allBots = new List<GameObject>();
		PlayerHealth playerHealth;

		public DeathmatchObjective(List<GameObject> bots)
		{
			allBots = bots;
			playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
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
			if (playerHealth.CurrentHealth > 0)
			{
				return false;
			}
			return true;
		}
	}
}

