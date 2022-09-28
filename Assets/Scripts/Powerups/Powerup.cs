using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(SphereCollider))]
	public abstract class Powerup : MonoBehaviour
	{
	    public abstract void Activate(GameObject player);

		void OnTriggerEnter(Collider other)
		{
			if (other.GetComponentInParent<PlayerMovement>() != null)
			{
				Activate(other.gameObject);
			}
		}
	}
}

