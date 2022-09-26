using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pistol : Weapon
	{
		public Transform gunTip;

		PoolManager pool;

		void Start()
		{
			pool = PoolManager.Instance;
		}

		
		public override void StartAttack()
		{
			pool.GetObjectOfTypeFromPool(PoolManager.PoolTag.Bullet, gunTip.position, gunTip.rotation);
		}

		public override void EndAttack()
		{

		}
	}
}

