using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class PlayerAttack : Attack
	{
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
			if (Input.GetKeyDown(KeyCode.R) && CurrentWeapon is Gun)
			{
				Gun gun = (Gun) CurrentWeapon;
				StartCoroutine(gun.Reload());
			}
		}

	}
}

