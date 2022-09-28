using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class LaserGun : Gun
	{
		[SerializeField] GameObject laserParticles;
		[SerializeField] float damageBurstInterval = .5f;

		GameObject owner;
		bool currentlyFiring = false;
		RaycastHit rayHit;

	    public override void StartAttack(GameObject owner)
		{
			if (AmmoLoaded)
			{
				currentlyFiring = true;
				laserParticles.SetActive(true);
				StartCoroutine(ShootLaser());
			}
		}

		IEnumerator ShootLaser()
		{
			while (AmmoLoaded && currentlyFiring)
			{
				if (Physics.Raycast(gunTip.position, gunTip.forward, out rayHit, 1000f))
				{
					Health health = rayHit.collider.GetComponentInParent<Health>();
					if (health != null)
					{
						health.Damage(new AttackData(owner, damage));
					}
				}
				currentClipAmmo--;
				yield return new WaitForSeconds(damageBurstInterval);
			}
			laserParticles.SetActive(false);
		}

		public override void EndAttack()
		{
			currentlyFiring = false;
			laserParticles.SetActive(false);
			StopCoroutine(ShootLaser());
		}

		public override void SecondaryAttack(GameObject owner)
		{

		}
	}
}
