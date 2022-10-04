using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public abstract class Attack : MonoBehaviour
	{
		[SerializeField] Transform weaponHolder;

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
			if (currentWeapon != null)
			{
				Destroy(currentWeapon.gameObject);
			}
			newWeapon.transform.SetParent(weaponHolder);
			newWeapon.transform.localPosition = Vector3.zero;
			newWeapon.transform.localEulerAngles = Vector3.zero;
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

