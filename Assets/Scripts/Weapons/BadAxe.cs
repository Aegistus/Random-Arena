using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BadAxe : Weapon
	{
		Animator anim;

		void Awake()
		{
			anim = GetComponent<Animator>();
		}

	    public override void StartAttack()
		{
			anim.Play("Attack");
		}

		public override void EndAttack()
		{
			print("End attack");
		}
	}
}

