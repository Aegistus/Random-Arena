using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotController : MonoBehaviour
	{
		[SerializeField] float updateInterval = .2f;
		[SerializeField] float attackInterval = .5f;
		[SerializeField] float attackRange = 1f;

	    protected BotMovement movement;
		protected BotAttack attack;
		protected GameObject target;

		void Start()
		{
			target = FindObjectOfType<PlayerHealth>().gameObject;
			movement = GetComponent<BotMovement>();
			attack = GetComponent<BotAttack>();
			movement.SetDestination(target.transform.position);
			StartCoroutine(UpdateTargetLocation());
			StartCoroutine(CheckForAttack());
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
				yield return new WaitForSeconds(attackInterval);
				if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
				{
					attack.StartAttack();
				}
			}
		}
	}
}

