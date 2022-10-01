using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AmmoPowerup : Powerup
	{
		[SerializeField] int amountOfAmmoRestored = 20;
	    public override void Activate(GameObject player)
		{
			Weapon playerWeapon = player.GetComponentInParent<PlayerAttack>().CurrentWeapon;
			if (playerWeapon is Gun)
			{
				((Gun)playerWeapon).AddAmmo(amountOfAmmoRestored);
				SoundManager.instance.PlaySoundAtPosition("Ammo Pickup", transform.position);
				Destroy(gameObject);
			}
		}
	}
}

