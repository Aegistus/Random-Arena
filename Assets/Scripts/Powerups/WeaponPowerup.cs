using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class WeaponPowerup : MonoBehaviour
	{
		[SerializeField] GameObject model;
		[SerializeField] GameObject[] weaponPrefabs;
		[SerializeField] float respawnDelay = 10f;
		bool spawned = true;

		void OnTriggerEnter(Collider other)
		{
			if (!spawned)
			{
				return;
			}
			PlayerAttack attack = other.GetComponentInParent<PlayerAttack>();
			if (attack != null)
			{
				int randIndex = (int)Random.Range(0, weaponPrefabs.Length);
				GameObject weapon = Instantiate(weaponPrefabs[randIndex]);
				attack.ChangeWeapon(weapon.GetComponent<Weapon>());
				StartCoroutine(RespawnDelay());
			}
		}

		IEnumerator RespawnDelay()
		{
			model.SetActive(false);
			spawned = false;
			yield return new WaitForSeconds(respawnDelay);
			model.SetActive(true);
			spawned = true;
		}
	}
}

