using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] float walkSpeed = 5;
		[SerializeField] float jumpHeight = 5f;

		CharacterController charController;
		float groundedTimer;
		float verticalVelocity = 0f;

		void Awake()
		{
			charController = GetComponent<CharacterController>();
		}

		void Update()
		{
			bool playerGrounded = charController.isGrounded;

			if (playerGrounded)
			{
				groundedTimer = .2f;
				if (verticalVelocity < 0)
				{
					verticalVelocity = 0f;
				}
			}
			if (groundedTimer > 0)
			{
				groundedTimer -= Time.deltaTime;
			}
			verticalVelocity += Physics.gravity.y * Time.deltaTime;

			Vector3 moveVector = Vector3.zero;
			if (Input.GetKey(KeyCode.W))
			{
				moveVector += transform.forward;
			}
			if (Input.GetKey(KeyCode.S))
			{
				moveVector += -transform.forward;
			}
			if (Input.GetKey(KeyCode.A))
			{
				moveVector += -transform.right;
			}
			if (Input.GetKey(KeyCode.D))
			{
				moveVector += transform.right;
			}

			if (Input.GetKeyDown(KeyCode.Space) && groundedTimer > 0)
			{
				groundedTimer = 0f;
				verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * -Physics.gravity.y);
				print("Jump");
			}
			moveVector *= walkSpeed;
			moveVector *= Globals.playerMoveSpeedMod;
			moveVector.y = verticalVelocity;
			charController.Move(moveVector * Time.deltaTime);
		}
	}
}

