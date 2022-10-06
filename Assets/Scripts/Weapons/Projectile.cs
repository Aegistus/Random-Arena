using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Projectile : MonoBehaviour
	{
	    public float speed = 50f;
		public float damage = 20f;
		
		GameObject owner;
		string impactSound = "Bullet Impact";
		int soundID;
		
		void Start()
		{
			soundID = SoundManager.instance.GetSoundID(impactSound);
		}

		public void SetOwner(GameObject owner)
		{
			this.owner = owner;
		}

		void Update()
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		}

		void OnTriggerEnter(Collider other)
		{
			SoundManager.instance.PlaySoundAtPosition(soundID, transform.position);
			Health otherHealth = other.GetComponentInParent<Health>();
			if (otherHealth != null)
			{
				otherHealth.Damage(new AttackData(owner, damage));
			}
		}
	}
}

