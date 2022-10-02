using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
	public class ObjectivesUI : MonoBehaviour
	{
	    [SerializeField] TMP_Text objectiveDescription;
		[SerializeField] TMP_Text ruleDescription;

		void Awake()
		{
			GameManager.OnObjectiveDeclared += UpdateText;
		}

		void UpdateText(Objective objective, Rule rule)
		{
			objectiveDescription.text = objective.Description;
			if (rule != null)
			{
				ruleDescription.text = rule.Description;
			}
		}
	}
}

