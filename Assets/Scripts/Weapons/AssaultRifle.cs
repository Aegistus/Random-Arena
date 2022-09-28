using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AssaultRifle : Gun
	{
		[SerializeField] float shotDelay = .2f;

		PoolManager pool;
		GameObject owner;
		bool currentlyFiring = false;

		void Start()
		{
			pool = PoolManager.Instance;
		}

	    public override void StartAttack(GameObject owner)
		{
			this.owner = owner;
			currentlyFiring = true;
			StartCoroutine(Shoot());
		}

		public override void EndAttack()
		{
			StopCoroutine(Shoot());
			currentlyFiring = false;
		}

		public override void SecondaryAttack(GameObject owner)
		{

		}

		IEnumerator Shoot()
		{
			while (AmmoLoaded && currentlyFiring)
			{
				GameObject bullet = pool.GetObjectOfTypeFromPool(PoolManager.PoolTag.Bullet, gunTip.position, gunTip.rotation);
				bullet.GetComponent<Projectile>().SetOwner(owner);
				anim.Play("Shoot");
				readyToFire = false;
				currentClipAmmo--;
				currentClipAmmo--;
				yield return new WaitForSeconds(shotDelay);
			}
		}
	}
}

