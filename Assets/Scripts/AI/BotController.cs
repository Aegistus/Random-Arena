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
		bool attacking = false;

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
			WaitForSeconds waitForSeconds = new WaitForSeconds(updateInterval);
			while (true)
			{
				yield return waitForSeconds;
				if (!attacking)
				{
					movement.SetDestination(target.transform.position);
				}
			}
		}

		IEnumerator CheckForAttack()
		{
			WaitForSeconds wait = new WaitForSeconds(attackInterval);
			while (true)
			{
				yield return wait;
				if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
				{
					attacking = true;
					attack.StartAttack();
				}
				else
				{
					attacking = false;
				}
			}
		}
	}
}

