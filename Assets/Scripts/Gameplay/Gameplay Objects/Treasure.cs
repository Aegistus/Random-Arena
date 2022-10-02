using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Treasure : MonoBehaviour
	{
		public static int TreasuresRemaining { get; private set; }
		static List<Treasure> allTreasures = new List<Treasure>();

		public static void ActivateTreasures(int numOfTreasures)
		{
			List<Treasure> toActivate = new List<Treasure>();
			if (numOfTreasures > allTreasures.Count)
			{
				numOfTreasures = allTreasures.Count;
			}
			for (int i = 0; i < numOfTreasures; i++)
			{
				int randIndex = (int) Random.Range(0, allTreasures.Count);
				toActivate.Add(allTreasures[randIndex]);
				allTreasures.RemoveAt(randIndex);
			}
			for (int i = 0; i < toActivate.Count; i++)
			{
				toActivate[i].Activate();
			}
			TreasuresRemaining = toActivate.Count;
		}

		[SerializeField] GameObject model;

	    public bool Collected { get; private set; } = false;

		void Awake()
		{
			allTreasures.Add(this);
			model.SetActive(false);
		}

		public void Activate()
		{
			model.SetActive(true);
			Collected = false;
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.GetComponentInParent<PlayerHealth>())
			{
				Collected = true;
				model.SetActive(false);
				SoundManager.instance.PlaySoundAtPosition("Task Complete", transform.position);
				TreasuresRemaining--;
			}
		}

	}
}

