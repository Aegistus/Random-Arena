using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TreasureHuntObjective : Objective
	{
		public TreasureHuntObjective()
		{
			Description = "Treasure Hunt: Find and collect all gold skulls to win.";
		}

	    public override void Setup()
		{
			Treasure.ActivateTreasures(10);
		}

		public override bool Completed()
		{
			return Treasure.TreasuresRemaining == 0;
		}
	}
}

