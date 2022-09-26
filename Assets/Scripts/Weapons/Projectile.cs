using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Projectile : MonoBehaviour
	{
	    public float speed = 50f;
		public float damage = 20f;

		void Update()
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		}

		void OnCollisionEnter(Collision collision)
		{
			Health otherHealth = collision.collider.GetComponentInParent<Health>();
			if (otherHealth != null)
			{
				otherHealth.Damage(damage);
			}
			//gameObject.SetActive(false);
		}
	}
}

