using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class DamageIndicatorUI : MonoBehaviour
	{
	    [SerializeField] Image damageVignette;
		[SerializeField] float fadeDuration = 2f;


		PlayerHealth health;
		float lastHealth = 0;

		void Start()
		{
			health = FindObjectOfType<PlayerHealth>();
			health.OnHealthChange += CheckForDamage;
			damageVignette.gameObject.SetActive(false);
			lastHealth = health.CurrentHealth;
		}

		void CheckForDamage(float currentHealth, float maxHealth)
		{
			if (currentHealth < lastHealth)
			{
				StartCoroutine(DisplayIndicator());
			}
			lastHealth = currentHealth;
		}

		IEnumerator DisplayIndicator()
		{
			damageVignette.gameObject.SetActive(true);
			damageVignette.CrossFadeAlpha(0, fadeDuration, false);
			yield return new WaitForSeconds(fadeDuration);
			Color color = damageVignette.color;
			color.a = 1;
			damageVignette.color = color;
			damageVignette.gameObject.SetActive(false);
		}
	}
}

