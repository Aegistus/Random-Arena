using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Gun : Weapon
	{
		[SerializeField] protected int maxClipAmmo;
	    [SerializeField] protected int maxCarriedAmmo;

		public bool AmmoLoaded => currentClipAmmo > 0;
		protected int currentClipAmmo;
		protected int currentCarriedAmmo;

		protected virtual void Awake()
		{
			currentCarriedAmmo = maxClipAmmo;
			currentCarriedAmmo = maxCarriedAmmo;
		}

		public void Reload()
		{
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
		}
	}
}

