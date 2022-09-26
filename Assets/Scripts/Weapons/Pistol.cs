using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pistol : Weapon
	{
		public Transform gunTip;

		PoolManager pool;
		Animator anim;

		void Start()
		{
			pool = PoolManager.Instance;
			anim = GetComponent<Animator>();
		}

		
		public override void StartAttack()
		{
			pool.GetObjectOfTypeFromPool(PoolManager.PoolTag.Bullet, gunTip.position, gunTip.rotation);
			anim.Play("Shoot");
		}

		public override void EndAttack()
		{

		}
	}
}

