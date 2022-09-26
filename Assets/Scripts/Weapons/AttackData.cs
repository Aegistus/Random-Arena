using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AttackData
	{
	    public GameObject owner;
		public float damage;

		public AttackData(GameObject owner, float damage)
		{
			this.owner = owner;
			this.damage = damage;
		}
	}
}

