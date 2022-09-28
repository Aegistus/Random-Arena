using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class HealthPowerup : Powerup
	{
		[SerializeField] float healthRestored = 20f;

	    public override void Activate(GameObject player)
		{
			PlayerHealth health = player.GetComponentInParent<PlayerHealth>();
			if (health.CurrentHealth < health.MaxHealth)
			{
				health.Heal(healthRestored);
				Destroy(gameObject);
			}
		}
	}
}

