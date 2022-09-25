using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
	public class Health : MonoBehaviour
	{
		/// Parameters: currentHealth, maxHealth
		public event Action<float, float> OnHealthChange;

		[SerializeField] protected float startingHealth = 100f;
	    [SerializeField] protected float maxHealth = 100f;

		[HideInInspector] public float currentHealth;

		protected virtual void Awake()
		{
			currentHealth = startingHealth;
			OnHealthChange?.Invoke(currentHealth, maxHealth);
		}
		
		public virtual void Damage(float damage)
		{
			currentHealth -= damage;
			if (currentHealth <= 0)
			{
				currentHealth = 0;
				Die();
			}
			OnHealthChange?.Invoke(currentHealth, maxHealth);
		}

		public virtual void Heal(float heal)
		{
			currentHealth += heal;
			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}
			OnHealthChange?.Invoke(currentHealth, maxHealth);
		}

		public virtual void Die()
		{
			gameObject.SetActive(false);
		}
	}
}
