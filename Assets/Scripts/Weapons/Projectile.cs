using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Projectile : MonoBehaviour
	{
	    public float speed = 50f;
		public float damage = 20f;
		
		GameObject owner;

		public void SetOwner(GameObject owner)
		{
			this.owner = owner;
		}

		void Update()
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		}

		void OnTriggerEnter(Collider other)
		{
			Health otherHealth = other.GetComponentInParent<Health>();
			if (otherHealth != null)
			{
				otherHealth.Damage(new AttackData(owner, damage));
			}
		}
	}
}

