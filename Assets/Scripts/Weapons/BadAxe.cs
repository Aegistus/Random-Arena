using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BadAxe : Weapon
	{
	    public override void StartAttack()
		{
			print("Attack");
		}

		public override void EndAttack()
		{
			print("End attack");
		}
	}
}

