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
		float attackRangeSquared;
		WaitForSeconds attackWait;
		WaitForSeconds updateWait;

		void Start()
		{
			attackWait = new WaitForSeconds(attackInterval);
			updateWait = new WaitForSeconds(updateInterval);
			target = FindObjectOfType<PlayerHealth>().gameObject;
			movement = GetComponent<BotMovement>();
			attack = GetComponent<BotAttack>();
			movement.SetDestination(target.transform.position);
			StartCoroutine(UpdateTargetLocation());
			StartCoroutine(CheckForAttack());
			attackRangeSquared = Mathf.Pow(attackRange, 2);
			movement.LookTarget = target.transform;
		}

		IEnumerator UpdateTargetLocation()
		{
			while (true)
			{
				yield return updateWait;
				if (!attacking)
				{
					movement.SetDestination(target.transform.position);
				}
			}
		}

		IEnumerator CheckForAttack()
		{
			while (true)
			{
				yield return attackWait;
				if ((transform.position - target.transform.position).sqrMagnitude < attackRangeSquared)
				{
					attacking = true;
					attack.StartAttack();
					movement.RotateTowardsTarget();
				}
				else
				{
					attacking = false;
				}
			}
		}
	}
}

