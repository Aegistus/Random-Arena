using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
	    Objective[] objectivePool;

		Objective currentObjective;

		void Awake()
		{

		}

		void Update()
		{
			if (currentObjective.Completed())
			{
				WinGame();
			}
			if (currentObjective.Failed())
			{
				LoseGame();
			}
		}

		void WinGame()
		{
			
		}

		void LoseGame()
		{

		}
	}
}

