using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Weapon : MonoBehaviour
	{
		public string weaponName;

	    public abstract void StartAttack(GameObject attacker);

		public abstract void EndAttack();

		public abstract void SecondaryAttack(GameObject attacker);

	}
}

