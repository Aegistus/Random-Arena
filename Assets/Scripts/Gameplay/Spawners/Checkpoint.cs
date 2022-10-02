using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class Checkpoint : MonoBehaviour
	{
		public static event Action<Checkpoint> OnCheckpointReached;

	    public bool Reached { get; private set; } = false;

		void Awake()
		{
			RaceCourse.AddCheckpoint(this);
			gameObject.SetActive(false);
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.GetComponentInParent<PlayerMovement>())
			{
				Reached = true;
				OnCheckpointReached?.Invoke(this);
				gameObject.SetActive(false);
			}
		}
	}
}

