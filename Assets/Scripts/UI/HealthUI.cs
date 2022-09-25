using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class HealthUI : MonoBehaviour
	{
	    [SerializeField] Text healthValue;
		[SerializeField] RectTransform healthBar;

		PlayerHealth health;
		float startingWidth;

		void Awake()
		{
			health = FindObjectOfType<PlayerHealth>();
			health.OnHealthChange += UpdateUI;
			startingWidth = healthBar.sizeDelta.x;
		}

		void UpdateUI(float currentHealth, float maxHealth)
		{
			healthValue.text = currentHealth + "";
			Vector2 sizeDelta = healthBar.sizeDelta;
			sizeDelta.x = Mathf.Lerp(0, startingWidth, currentHealth / maxHealth);
			healthBar.sizeDelta = sizeDelta;
		}
	}
}

