using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
	public class WeaponInfoUI : MonoBehaviour
	{
	    [SerializeField] TMP_Text weaponName;

		PlayerAttack playerAttack;

		void Awake()
		{
			playerAttack = FindObjectOfType<PlayerAttack>();
			playerAttack.OnWeaponChange += UpdateWeapon;
		}

		void UpdateWeapon(Weapon weapon)
		{
			weaponName.text = weapon.weaponName;
		}


	}
}

