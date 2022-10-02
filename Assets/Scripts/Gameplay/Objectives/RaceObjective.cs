using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class RaceObjective : Objective
	{
		public RaceObjective()
		{
			Description = "Race: Go through all checkpoints to win.";
		}

		public override void Setup()
		{
			RaceCourse.GenerateRaceCourse();
		}

		public override bool Completed()
		{
			return RaceCourse.CourseFinished;
		}
	}
}
