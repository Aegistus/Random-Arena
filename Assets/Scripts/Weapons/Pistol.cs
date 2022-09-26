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

		
		public override void StartAttack(GameObject owner)
		{
			GameObject bullet = pool.GetObjectOfTypeFromPool(PoolManager.PoolTag.Bullet, gunTip.position, gunTip.rotation);
			bullet.GetComponent<Projectile>().SetOwner(owner);
			anim.Play("Shoot");
		}

		public override void EndAttack()
		{

		}
	}
}

