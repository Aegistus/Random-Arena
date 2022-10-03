using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class OnePlayerLifeRule : Rule
	{
		bool playerDead = false;

		public OnePlayerLifeRule()
		{
			Description = "One Life: The player gets only one life.";
		}

		public override void Activate()
		{
			GameObject.FindObjectOfType<PlayerHealth>().OnDeath += PlayerDied;
		}

		void PlayerDied()
		{
			playerDead = true;
		}

	    public override bool Broken()
		{
			return playerDead;
		}
	}
}

