using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public abstract class Attack : MonoBehaviour
	{
		public Weapon CurrentWeapon => currentWeapon;
		Weapon currentWeapon;

		public event Action<Weapon> OnWeaponChange;

		protected virtual void Start()
		{
			if (currentWeapon == null)
			{
				ChangeWeapon(GetComponentInChildren<Weapon>());
			}
		}

		public void ChangeWeapon(Weapon newWeapon)
		{
			currentWeapon = newWeapon;
			OnWeaponChange?.Invoke(currentWeapon);
		}
	    
		public virtual void StartAttack()
		{
			currentWeapon.StartAttack(gameObject);
		}

		public virtual void EndAttack()
		{
			currentWeapon.EndAttack();
		}

		public virtual void SecondaryAttack()
		{
			currentWeapon.SecondaryAttack(gameObject);
		}
	}
}

