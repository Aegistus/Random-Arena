using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class RaceObjective : Objective
	{
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
