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

