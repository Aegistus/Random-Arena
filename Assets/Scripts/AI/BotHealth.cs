using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotHealth : Health
	{
		[SerializeField] GameObject hitParticles;
		[SerializeField] GameObject deathParticles;
		[SerializeField] GameObject[] botParts;

		void Awake()
		{
			hitParticles.SetActive(false);
			deathParticles.SetActive(false);
		}		

		public override void Damage(AttackData data)
		{
			base.Damage(data);
			Vector3 randPos = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
			hitParticles.transform.position = transform.position + randPos;
			hitParticles.SetActive(true);
			if (gameObject.activeInHierarchy)
			{
				StartCoroutine(ParticleHide());
			}
		}

		IEnumerator ParticleHide()
		{
			yield return new WaitForSeconds(3f);
			hitParticles.SetActive(false);
		}

	    public override void Die()
		{
			base.Die();
			deathParticles.SetActive(true);
			deathParticles.transform.SetParent(null, true);
			foreach (var part in botParts)
			{
				part.AddComponent<Rigidbody>();
				part.AddComponent<Despawner>();
				part.transform.SetParent(null, true);
			}
			gameObject.SetActive(false);
		}
	}
}

