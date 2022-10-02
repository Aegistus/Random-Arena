using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TreasureHuntObjective : Objective
	{
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

