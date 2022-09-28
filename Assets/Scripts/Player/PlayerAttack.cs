using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class PlayerAttack : MonoBehaviour
	{
	    public Weapon currentWeapon;

		public event Action<Weapon> OnWeaponChange;

		void Start()
		{
			if (currentWeapon == null)
			{
				currentWeapon = GetComponentInChildren<Weapon>();
			}
			OnWeaponChange?.Invoke(currentWeapon);
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				StartAttack();
			}
			if (Input.GetMouseButtonUp(0))
			{
				EndAttack();
			}
			if (Input.GetMouseButtonDown(1))
			{
				SecondaryAttack();
			}
			if (Input.GetKeyDown(KeyCode.R) && currentWeapon is Gun)
			{
				Gun gun = (Gun) currentWeapon;
				StartCoroutine(gun.Reload());
			}
		}

		void StartAttack()
		{
			currentWeapon.StartAttack(gameObject);
		}

		void EndAttack()
		{
			currentWeapon.EndAttack();
		}

		void SecondaryAttack()
		{
			currentWeapon.SecondaryAttack(gameObject);
		}
	}
}

