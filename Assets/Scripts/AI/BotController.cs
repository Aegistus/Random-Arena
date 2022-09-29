using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotController : MonoBehaviour
	{
		[SerializeField] float updateInterval = .2f;
		[SerializeField] float attackRange = 1f;

	    protected BotMovement movement;
		protected GameObject target;

		void Start()
		{
			target = FindObjectOfType<PlayerHealth>().gameObject;
			movement = GetComponent<BotMovement>();
			movement.SetDestination(target.transform.position);
			StartCoroutine(UpdateTargetLocation());
		}

		IEnumerator UpdateTargetLocation()
		{
			while (true)
			{
				yield return new WaitForSeconds(updateInterval);
				movement.SetDestination(target.transform.position);
			}
		}

		IEnumerator CheckForAttack()
		{
			while (true)
			{
				yield return new WaitForSeconds(updateInterval);
				if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
				{
					
				}
			}
		}
	}
}

