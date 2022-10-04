using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Game
{
	public class EnemySpawner : MonoBehaviour
	{
		public static event Action OnFinishedSpawning;

		[SerializeField] GameObject[] enemyPrefabs;
		[SerializeField] Transform spawnPoint;
		[SerializeField] GameObject particleEffects;
		[SerializeField] float spawnDelay = 3f;

		static List<EnemySpawner> allSpawners = new List<EnemySpawner>();
		int respawns;
		float respawnDelay;

	    public static void GlobalSpawnEnemies(int respawns, float respawnDelay)
		{
			for (int i = 0; i < allSpawners.Count; i++)
			{
				allSpawners[i].StartSpawn(respawns, respawnDelay);
			}
		}

		void Awake()
		{
			allSpawners.Add(this);
			particleEffects.SetActive(false);
		}

		public void StartSpawn(int respawns, float respawnDelay)
		{
			this.respawns = respawns;
			this.respawnDelay = respawnDelay;
			StartCoroutine(SpawnAfterDelay());
		}

		IEnumerator SpawnAfterDelay()
		{
			while (respawns > 0)
			{
				particleEffects.SetActive(true);
				yield return new WaitForSeconds(spawnDelay);
				Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint.position, spawnPoint.rotation);
				particleEffects.SetActive(false);
				respawns--;
				yield return new WaitForSeconds(respawnDelay);
			}
			OnFinishedSpawning?.Invoke();
		}

		void OnDisable()
		{
			allSpawners.Remove(this);
		}
	}
}

