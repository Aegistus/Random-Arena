using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerHealth : Health
	{
		[SerializeField] float fallDamage = 10f;
		[SerializeField] float fallDamageThreshold = 10f;
		CharacterController controller;
		float lastYVelocity = 0;

		void Awake()
		{
			controller = GetComponent<CharacterController>();
		}

	    public override bool Damage(AttackData data)
		{
			data.damage *= Globals.playerDamageTakenMod;
			bool successful = base.Damage(data);
			SoundManager.instance.PlaySoundAtPosition("Player Impact", transform.position);
			return successful;
		}

		public override void Heal(float heal)
		{
			base.Heal(heal * Globals.playerHealTakenMod);
			SoundManager.instance.PlaySoundAtPosition("Heal", transform.position);
		}

		public override void Die()
		{
			GetComponent<PlayerMovement>().enabled = false;
			GetComponent<PlayerAttack>().enabled = false;
			base.Die();
		}

		void FixedUpdate()
		{
			float acceleration = controller.velocity.y - lastYVelocity;
			//print(acceleration);
			if (acceleration > fallDamageThreshold && lastYVelocity < 0)
			{
				float damage = (int)(acceleration - fallDamageThreshold) * fallDamage;
				Damage(new AttackData(null, damage * Globals.playerFallDamageMod));
			}
			lastYVelocity = controller.velocity.y;
		}
	}
}

