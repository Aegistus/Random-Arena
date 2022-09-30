using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotAttack : Attack
	{
	    [SerializeField] float attackDelay = 1f;

		bool canAttack = true;

		public override void StartAttack()
		{
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

