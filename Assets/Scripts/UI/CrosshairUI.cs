using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
	public class CrosshairUI : MonoBehaviour
	{
		public RectTransform crosshair;
		public TMP_Text distanceIndicator;
		public float movementSmooth = 5f;

		RaycastHit rayHit;
		PlayerAttack playerAttack;
		Camera mainCamera;

		void Start()
		{
			playerAttack = FindObjectOfType<PlayerAttack>();
			mainCamera = Camera.main;
		}

		
		void Update()
		{
			if (playerAttack.currentWeapon != null)
			{
				if (Physics.Raycast(playerAttack.currentWeapon.transform.position, playerAttack.currentWeapon.transform.forward, out rayHit, 100f))
				{
					crosshair.position = Vector3.Lerp(crosshair.position, mainCamera.WorldToScreenPoint(rayHit.point), movementSmooth * Time.deltaTime);
				}
				else 
				{
					crosshair.position = Vector3.Lerp(crosshair.position, mainCamera.WorldToScreenPoint(playerAttack.currentWeapon.transform.forward * 100), movementSmooth * Time.deltaTime);
				}
			}
			distanceIndicator.text = ((int)Vector3.Distance(playerAttack.transform.position, rayHit.point)) + "m";
		}
	}
}

