using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class RaceCourse
	{
		public static bool CourseFinished { get; private set; } = false;

		static Queue<Checkpoint> raceCourse = new Queue<Checkpoint>();
		static Checkpoint currentCheckpoint;
	    static List<Checkpoint> allCheckpoints = new List<Checkpoint>();

		public static void AddCheckpoint(Checkpoint checkpoint)
		{
			allCheckpoints.Add(checkpoint);
		}

		public static void GenerateRaceCourse()
		{
			while (allCheckpoints.Count > 0)
			{
				int randIndex = (int) Random.Range(0, allCheckpoints.Count);
				raceCourse.Enqueue(allCheckpoints[randIndex]);
				allCheckpoints.RemoveAt(randIndex);
			}
			currentCheckpoint = raceCourse.Dequeue();
			currentCheckpoint.gameObject.SetActive(true);
			Checkpoint.OnCheckpointReached += UpdateCourse;
		}

		public static void UpdateCourse(Checkpoint justReachedCheckpoint)
		{
			if (justReachedCheckpoint == currentCheckpoint)
			{
				if (raceCourse.Count == 0)
				{
					CourseFinished = true;
				}
				else
				{
					currentCheckpoint = raceCourse.Dequeue();
					currentCheckpoint.gameObject.SetActive(true);
				}
			}
		}
	}
}

