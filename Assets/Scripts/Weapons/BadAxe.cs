using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BadAxe : Weapon
	{
		[SerializeField] float damage = 20f;

		Animator anim;
		bool attacking = false;
		float attackTime = .75f;

		void Awake()
		{
			anim = GetComponent<Animator>();
		}

	    public override void StartAttack()
		{
			anim.Play("Attack");
			attacking = true;
		}

		IEnumerator AttackTimer()
		{
			yield return new WaitForSeconds(attackTime);
			attacking = false;
		}

		public override void EndAttack()
		{
			//print("End attack");
		}

		void OnTriggerEnter(Collider other)
		{
			print("Trigger entered");
			if (attacking)
			{
				Health health = other.GetComponentInParent<Health>();
				if (health != null)
				{
					health.Damage(damage);
					attacking = false;
				}
			}
		}
	}
}

