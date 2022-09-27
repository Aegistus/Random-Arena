using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BadAxe : Weapon
	{
		[Header("Melee")]
		[SerializeField] float meleeDamage = 20f;
		[Header("Throwing Mode")]
		[SerializeField] float throwingDamage = 50f;
		[SerializeField] float spinSpeed = 100f;
		[SerializeField] float throwSpeed = 20f;
		[SerializeField] float returnTime = 5f;

		Animator anim;
		bool attacking = false;
		float attackTime = .75f;
		GameObject owner = null;

		// for throwing purposes
		bool beingThrown = false;
		Vector3 originalLocalPosition;
		Transform originalParent;
		Quaternion originalRotation;

		void Awake()
		{
			anim = GetComponent<Animator>();
			originalLocalPosition = transform.localPosition;
			originalParent = transform.parent;
			originalRotation = transform.GetChild(0).localRotation;
		}

	    public override void StartAttack(GameObject owner)
		{
			if (beingThrown)
			{
				return;
			}
			this.owner = owner;
			anim.Play("Attack");
			attacking = true;
			StartCoroutine(AttackTimer());
		}

		IEnumerator AttackTimer()
		{
			yield return new WaitForSeconds(attackTime);
			attacking = false;
		}

		public override void EndAttack()
		{
			//print("End attack");
		}

		public override void SecondaryAttack(GameObject owner)
		{
			if (attacking)
			{
				return;
			}
			beingThrown = true;
			this.owner = owner;
			transform.SetParent(null, true);
			StartCoroutine(ReturnToOwner());
			anim.enabled = false;
		}

		IEnumerator ReturnToOwner()
		{
			yield return new WaitForSeconds(returnTime);
			beingThrown = false;
			transform.parent = originalParent;
			transform.localPosition = originalLocalPosition;
			transform.GetChild(0).localRotation = originalRotation;
			anim.enabled = true;
		}

		void Update()
		{
			if (beingThrown)
			{
				transform.Translate(Vector3.forward * throwSpeed * Time.deltaTime, Space.Self);
				transform.GetChild(0).Rotate(spinSpeed * Time.deltaTime, 0, 0);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			//print("Trigger entered");
			if (attacking)
			{
				Health health = other.GetComponentInParent<Health>();
				if (health != null)
				{
					float damage = beingThrown ? throwingDamage : meleeDamage;
					health.Damage(new AttackData(owner, damage));
					beingThrown = false;
					attacking = false;
				}
			}
		}
	}
}

