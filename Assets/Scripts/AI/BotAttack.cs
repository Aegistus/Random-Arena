using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotAttack : Attack
	{
	    [SerializeField] float attackDelay = 1f;

		Gun gun;
		bool canAttack = true;
		bool reloading = false;
		WaitForSeconds attackWait;

		protected override void Start()
		{
			base.Start();
			if (CurrentWeapon is Gun)
			{
				gun = (Gun)CurrentWeapon;
			}
			attackWait = new WaitForSeconds(attackDelay);
		}

		public override void StartAttack()
		{
			if (gun != null)
			{
				if (!gun.AmmoLoaded && !reloading)
				{
					StartCoroutine(gun.Reload());
					reloading = true;
				}
				else
				{
					reloading = false;
				}
			}
			if (canAttack)
			{
				base.StartAttack();
				StartCoroutine(AttackDelay());
			}
		}

		IEnumerator AttackDelay()
		{
			canAttack = false;
			yield return attackWait;
			canAttack = true;
		}
	}
}

