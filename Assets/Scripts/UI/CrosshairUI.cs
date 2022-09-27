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
					crosshair.position = mainCamera.WorldToScreenPoint(rayHit.point);
				}
				else 
				{
					crosshair.position = mainCamera.WorldToScreenPoint(playerAttack.currentWeapon.transform.forward * 100);
				}
			}
			distanceIndicator.text = ((int)Vector3.Distance(playerAttack.transform.position, rayHit.point)) + "m";
		}
	}
}

