using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerHealth : Health
	{
	    public override void Damage(AttackData data)
		{
			data.damage *= Globals.playerDamageTakenMod;
			base.Damage(data);
			SoundManager.instance.PlaySoundAtPosition("Player Impact", transform.position);
		}

		public override void Heal(float heal)
		{
			base.Heal(heal * Globals.playerHealTakenMod);
			SoundManager.instance.PlaySoundAtPosition("Heal", transform.position);
		}
	}
}

