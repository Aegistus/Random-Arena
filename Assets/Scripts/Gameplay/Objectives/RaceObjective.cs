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
			EnemySpawner.GlobalSpawnEnemies(2, 30f);
		}

		public override bool Completed()
		{
			return RaceCourse.CourseFinished;
		}
	}
}
