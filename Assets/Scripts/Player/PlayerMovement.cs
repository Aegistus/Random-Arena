using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] float walkSpeed = 5f;
		[SerializeField] float runSpeed = 10f;
		[SerializeField] float jumpHeight = 5f;
		[SerializeField] LayerMask groundLayer;

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

			// jump
			if (Input.GetKeyDown(KeyCode.Space) && groundedTimer > 0)
			{
				groundedTimer = 0f;
				verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * -Physics.gravity.y);
			}
			
			if (Input.GetKey(KeyCode.LeftShift) && playerGrounded)
			{
				moveVector *= runSpeed;
			}
			else
			{
				moveVector *= walkSpeed;
			}
			moveVector *= Globals.playerMoveSpeedMod;
			moveVector = AdjustVerticalVelocityOnSlope(moveVector);
			moveVector.y += verticalVelocity;

			charController.Move(moveVector * Time.deltaTime);
		}

		// Adjusts the vertical velocity of the player if on a slope to avoid bouncing.
		private Vector3 AdjustVerticalVelocityOnSlope(Vector3 velocity)
		{
			RaycastHit rayHit;
			if (Physics.Raycast(transform.position, Vector3.down, out rayHit, 3f, groundLayer))
			{
				Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, rayHit.normal);
				Vector3 adjustedVelocity = slopeRotation * velocity;
				if (adjustedVelocity.y < 0)
				{
					return adjustedVelocity;
				}
			}
			return velocity;
		}
	}
}

