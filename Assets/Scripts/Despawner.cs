using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Despawner : MonoBehaviour
	{
	    public float delay = 5f;

		void Awake()
		{
			StartCoroutine(DestroyAfterDelay());
		}

		IEnumerator DestroyAfterDelay()
		{
			yield return new WaitForSeconds(delay);
			Destroy(gameObject);
		}
	}
}

