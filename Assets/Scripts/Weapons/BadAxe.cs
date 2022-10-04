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
		[SerializeField] float returnSpeed = 5f;

		Animator anim;
		bool attacking = false;
		float attackTime = .75f;
		GameObject owner = null;

		// for throwing purposes
		bool beingThrown = false;
		Vector3 originalLocalPosition;
		Transform originalParent;
		Quaternion originalChildRotation;

		void Awake()
		{
			anim = GetComponent<Animator>();
			originalLocalPosition = transform.localPosition;
			originalParent = transform.parent;
			originalChildRotation = transform.GetChild(0).localRotation;
		}

	    public override void StartAttack(GameObject owner)
		{
			if (beingThrown || attacking)
			{
				return;
			}
			this.owner = owner;
			anim.Play("Attack");
			SoundManager.instance.PlaySoundAtPosition("Bad Axe Attack", transform.position);
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
			if (attacking || beingThrown)
			{
				return;
			}
			beingThrown = true;
			this.owner = owner;
			transform.SetParent(null, true);
			SoundManager.instance.PlaySoundAtPosition("Bad Axe Throw", transform.position);
			StartCoroutine(ReturnTimer());
			anim.enabled = false;
		}

		IEnumerator ReturnTimer()
		{
			yield return new WaitForSeconds(returnTime);
			beingThrown = false;
			while (Vector3.Distance(transform.position, owner.transform.position) >= .5f)
			{
				transform.position = Vector3.Lerp(transform.position, owner.transform.position, returnSpeed * Time.deltaTime);
				yield return null;
			}
			ResetAxe();
		}

		void ResetAxe()
		{
			beingThrown = false;
			transform.parent = originalParent;
			transform.localPosition = originalLocalPosition;
			transform.localEulerAngles = Vector3.zero;
			transform.GetChild(0).localRotation = originalChildRotation;
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
			if (attacking || beingThrown)
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

