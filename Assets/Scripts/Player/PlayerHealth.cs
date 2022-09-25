using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerHealth : Health
	{
	    public override void Damage(float damage)
		{
			base.Damage(damage * Globals.playerDamageTakenMod);
		}

		public override void Heal(float heal)
		{
			base.Heal(heal * Globals.playerHealTakenMod);
		}

		// test
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				Damage(10);
			}
			if (Input.GetKeyDown(KeyCode.F))
			{
				Heal(10);
			}
		}
	}
}

