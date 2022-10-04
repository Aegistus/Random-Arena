using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TreasureHuntObjective : Objective
	{
		int numOfTreasures = 10;

		public TreasureHuntObjective()
		{
			Description = "Treasure Hunt: Find and collect all gold skulls to win.";
		}

	    public override void Setup()
		{
			Treasure.ActivateTreasures(numOfTreasures);
			EnemySpawner.GlobalSpawnEnemies(3, 30f);
		}

		public override bool Completed()
		{
			return Treasure.TreasuresRemaining == 0;
		}
	}
}

