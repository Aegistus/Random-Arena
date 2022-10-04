using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TimerPanelUI : MonoBehaviour
	{
	    public GameObject[] digits;

		void Start()
		{
			foreach (var d in digits)
			{
				d.SetActive(false);
			}
		}

		public void SetDigit(int digit)
		{
			foreach (var d in digits)
			{
				d.SetActive(false);
			}
			digits[digit].SetActive(true);
		}
	}
}

