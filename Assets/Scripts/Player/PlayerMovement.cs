using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] float walkSpeed = 5;

		CharacterController charController;

		void Awake()
		{
			charController = GetComponent<CharacterController>();
		}

		void Update()
		{
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
			charController.Move(moveVector * walkSpeed * Time.deltaTime * Globals.playerMoveSpeedMod);
		}
	}
}

