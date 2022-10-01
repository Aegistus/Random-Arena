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

