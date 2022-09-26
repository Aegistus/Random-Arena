using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerAttack : MonoBehaviour
	{
	    public Weapon currentWeapon;

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
		}

		void StartAttack()
		{
			currentWeapon.StartAttack(gameObject);
		}

		void EndAttack()
		{
			currentWeapon.EndAttack();
		}
	}
}

