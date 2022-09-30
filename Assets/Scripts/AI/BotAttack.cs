using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotAttack : Attack
	{
	    [SerializeField] float attackDelay = 1f;

		bool canAttack = true;
		bool reloading = false;

		public override void StartAttack()
		{
			if (CurrentWeapon is Gun)
			{
				if (!((Gun)CurrentWeapon).AmmoLoaded)
				{
					if (reloading == false)
					{
						StartCoroutine(((Gun)CurrentWeapon).Reload());
						reloading = true;
					}
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
			yield return new WaitForSeconds(attackDelay);
			canAttack = true;
		}
	}
}

