using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aegis;

namespace Game
{
	public class TimerRule : Rule
	{
		float timerLength;
		bool timesUp = false;

		public TimerRule(float timerLength)
		{
			Description = "Timer: Objective must be completed before time runs out.";
			Timer.SetTimer(() => timesUp = true, timerLength);
		}

	    public override bool Broken()
		{
			return timesUp;
		}
	}
}

