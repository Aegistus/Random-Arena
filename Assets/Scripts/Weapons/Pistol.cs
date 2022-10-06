using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pistol : Gun
	{
		public float resetTime = .2f;

		PoolManager pool;
		string shotSound = "Revolver Shot";
		int shootID = Animator.StringToHash("Shoot");

		void Start()
		{
			pool = PoolManager.Instance;
		}

		
		public override void StartAttack(GameObject owner)
		{
			if (readyToFire && AmmoLoaded)
			{
				GameObject bullet = pool.GetObjectOfTypeFromPool(PoolManager.PoolTag.Bullet, gunTip.position, gunTip.rotation);
				bullet.GetComponent<Projectile>().SetOwner(owner);
				anim.Play(shootID);
				SoundManager.instance.PlaySoundAtPosition(shotSound, transform.position);
				readyToFire = false;
				currentClipAmmo--;
				StartCoroutine(ShotReset());
			}
		}

		IEnumerator ShotReset()
		{
			yield return new WaitForSeconds(resetTime);
			readyToFire = true;
		}

		public override void EndAttack()
		{

		}

		public override void SecondaryAttack(GameObject owner) {}
	}
}

