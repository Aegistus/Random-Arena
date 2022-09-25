using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TargetDummy : MonoBehaviour
	{
	    void Awake()
		{
			GetComponent<Health>().OnHealthChange += DisplayHealth;
		}

		void DisplayHealth(float currentHealth, float maxHealth)
		{
			print("Target Dummy Health: " + currentHealth);
		}
	}
}

