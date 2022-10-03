using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TimerUI : MonoBehaviour
	{
		public TimerPanelUI[] timerPanels;
		float timeLeft;

	    void Awake()
		{
			GameManager.OnObjectiveDeclared += CheckForTimerRule;
		}

		void CheckForTimerRule(Objective obj, Rule rule)
		{
			if (rule is TimerRule)
			{
				timeLeft = ((TimerRule)rule).TimerLength;
				StartCoroutine(Timer());
			}
		}

		IEnumerator Timer()
		{
			while (timeLeft > 0)
			{
				yield return new WaitForSeconds(1);
				timeLeft--;
				for (int i = 0; i < timerPanels.Length; i++)
				{
					int minutes = (int)timeLeft / 60;
					timerPanels[0].SetDigit((int)minutes / 10);
					timerPanels[1].SetDigit((int)minutes % 10);
					int seconds = (int)timeLeft % 60;
					timerPanels[2].SetDigit((int)seconds / 10);
					timerPanels[3].SetDigit((int)seconds % 10);
				}
			}
		}

		void OnDestroy()
		{
			GameManager.OnObjectiveDeclared -= CheckForTimerRule;
		}
	}
}

