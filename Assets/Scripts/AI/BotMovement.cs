using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
	public class BotMovement : MonoBehaviour
	{
		[SerializeField] float stoppingDistance;

	    NavMeshAgent navAgent;

		void Awake()
		{
			navAgent = GetComponent<NavMeshAgent>();
		}

		public void SetDestination(Vector3 position)
		{
			navAgent.SetDestination(position);
		}

		void Update()
		{
			if (Vector3.Distance(transform.position, navAgent.destination) <= stoppingDistance)
			{
				navAgent.SetDestination(transform.position);
			}
		}
	}
}

