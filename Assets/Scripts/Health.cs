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
		public event Action OnDeath;

		[SerializeField] protected float startingHealth = 100f;
	    [SerializeField] protected float maxHealth = 100f;

		public float MaxHealth => maxHealth;
		public float CurrentHealth => currentHealth;
		float currentHealth;
		bool isDead = false;

		protected virtual void Start()
		{
			currentHealth = startingHealth;
			OnHealthChange?.Invoke(currentHealth, maxHealth);
		}
		
		public virtual bool Damage(AttackData data)
		{
			// prevents attacking self.
			if (isDead)
			{
				return false;
			}
			if (data.owner == gameObject)
			{
				return false;
			}
			currentHealth -= data.damage;
			if (currentHealth <= 0 && !isDead)
			{
				currentHealth = 0;
				Die();
			}
			OnHealthChange?.Invoke(currentHealth, maxHealth);
			return true;
		}

		public virtual void Heal(float heal)
		{
			currentHealth += heal;
			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}
			if (isDead)
			{
				isDead = false;
			}
			OnHealthChange?.Invoke(currentHealth, maxHealth);
		}

		public virtual void Die()
		{
			isDead = true;
			OnDeath?.Invoke();
		}
	}
}

