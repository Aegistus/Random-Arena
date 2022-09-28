using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
	public class AmmoUI : MonoBehaviour
	{
	    [SerializeField] TMP_Text clipAmmo;
		[SerializeField] TMP_Text carriedAmmo;

		int lastClipAmmo = -1;
		int lastCarriedAmmo = -1;
		bool weaponUsesAmmo;

		PlayerAttack playerAttack;
		Weapon currentWeapon;

		void Awake()
		{
			playerAttack = FindObjectOfType<PlayerAttack>();
			playerAttack.OnWeaponChange += UpdateWeapon;
		}

		void UpdateWeapon(Weapon weapon)
		{
			currentWeapon = weapon;
			if (weapon is BadAxe)
			{
				weaponUsesAmmo = false;
			}
			else
			{
				weaponUsesAmmo = true;
			}
		}

		void Update()
		{
			if (weaponUsesAmmo)
			{
				Gun gun = (Gun) currentWeapon;
				if (lastClipAmmo != gun.CurrentAmmo)
				{
					clipAmmo.text = gun.CurrentAmmo + "";
				}
				if (lastCarriedAmmo != gun.CarriedAmmo)
				{
					carriedAmmo.text = gun.CarriedAmmo + "";
				}
				lastClipAmmo = gun.CurrentAmmo;
				lastCarriedAmmo = gun.CarriedAmmo;
			}
		}
	}
}

