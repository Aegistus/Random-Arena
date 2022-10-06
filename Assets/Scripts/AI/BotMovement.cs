using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
	public class BotMovement : MonoBehaviour
	{
		[SerializeField] float stoppingDistance;
		[SerializeField] float turnSpeed = 20f;

		public Transform LookTarget { get; set; }

		Vector3 destination;
	    NavMeshAgent navAgent;

		void Awake()
		{
			navAgent = GetComponent<NavMeshAgent>();
		}

		public void SetDestination(Vector3 position)
		{
			if (!navAgent.enabled)
			{
				return;
			}
			destination = position;
			navAgent.SetDestination(position);
		}

		void Update()
		{
			if (Vector3.Distance(transform.position, destination) <= stoppingDistance)
			{
				if (navAgent.enabled)
				{
					navAgent.SetDestination(transform.position);
					destination = transform.position;
					navAgent.enabled = false;
				}
			}
			else if (!navAgent.enabled)
			{
				navAgent.enabled = true;
			}
			RotateTowardsTarget();
		}

		Quaternion currentRotation, targetRotation;
		public void RotateTowardsTarget()
		{
			if (LookTarget != null)
			{
				//print("rotating");
				currentRotation = transform.rotation;
				transform.LookAt(LookTarget.position);
				targetRotation = transform.rotation;
				transform.rotation = currentRotation;
				transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, turnSpeed * Time.deltaTime);
			}
		}
	}
}

