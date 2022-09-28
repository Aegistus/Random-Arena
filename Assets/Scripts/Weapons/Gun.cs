using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Gun : Weapon
	{
		[SerializeField] protected int maxClipAmmo;
	    [SerializeField] protected int maxCarriedAmmo;
		[SerializeField] protected float reloadTime = 1f;

		public bool AmmoLoaded => currentClipAmmo > 0;
		protected int currentClipAmmo;
		protected int currentCarriedAmmo;
		protected bool readyToFire = true;
		protected Animator anim;

		protected virtual void Awake()
		{
			currentClipAmmo = maxClipAmmo;
			currentCarriedAmmo = maxCarriedAmmo;
			anim = GetComponent<Animator>();
		}

		public IEnumerator Reload()
		{
			readyToFire = false;
			anim.Play("Reload");
			yield return new WaitForSeconds(reloadTime);
			if (currentCarriedAmmo > 0 && currentClipAmmo < maxClipAmmo)
			{
				int refillAmount = maxClipAmmo - currentClipAmmo;
				if (currentCarriedAmmo >= refillAmount)
				{
					currentCarriedAmmo -= refillAmount;
					currentClipAmmo += refillAmount;
				}
				else
				{
					currentClipAmmo += currentCarriedAmmo;
					currentCarriedAmmo = 0;
				}
			}
			readyToFire = true;
		}
	}
}

