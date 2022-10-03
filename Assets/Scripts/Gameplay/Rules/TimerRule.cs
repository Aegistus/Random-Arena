using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aegis;

namespace Game
{
	public class TimerRule : Rule
	{
		public float TimerLength { get; private set; }
		bool timesUp = false;

		public TimerRule(float timerLength)
		{
			Description = "Timer: Objective must be completed before time runs out.";
			TimerLength = timerLength;
			Timer.SetTimer(() => timesUp = true, timerLength);
		}

	    public override bool Broken()
		{
			return timesUp;
		}
	}
}

