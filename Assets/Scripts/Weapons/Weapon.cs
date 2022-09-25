using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Weapon : MonoBehaviour
	{
	    public abstract void StartAttack();

		public abstract void EndAttack();
		
	}
}

