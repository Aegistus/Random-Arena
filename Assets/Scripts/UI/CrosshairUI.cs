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
		public float rangeFinderUpdateInterval = .2f;
		public bool crosshairEnabled = true;

		RaycastHit rayHit;
		PlayerAttack playerAttack;
		Camera mainCamera;

		void Awake()
		{
			playerAttack = FindObjectOfType<PlayerAttack>();
			playerAttack.OnWeaponChange += UpdateWeapon;
			mainCamera = Camera.main;
			StartCoroutine(UpdateRangeFinder());
		}

		void UpdateWeapon(Weapon weapon)
		{
			if (weapon is BadAxe)
			{
				crosshairEnabled = false;
				crosshair.gameObject.SetActive(false);
			}
			else
			{
				crosshairEnabled = true;
				crosshair.gameObject.SetActive(true);
			}
		}
		
		void Update()
		{
			if (playerAttack.CurrentWeapon != null && crosshairEnabled)
			{
				Gun gun = (Gun)playerAttack.CurrentWeapon;
				if (Physics.Raycast(gun.GunTip.position, gun.GunTip.forward, out rayHit, 100f))
				{
					crosshair.position = Vector3.Lerp(crosshair.position, mainCamera.WorldToScreenPoint(rayHit.point), movementSmooth * Time.deltaTime);
				}
				else
				{
					crosshair.position = Vector3.Lerp(crosshair.position, mainCamera.WorldToScreenPoint(gun.GunTip.forward * 100), movementSmooth * Time.deltaTime);
				}
			}
		}

		IEnumerator UpdateRangeFinder()
		{
			while (true)
			{
				distanceIndicator.text = ((int)Vector3.Distance(playerAttack.transform.position, rayHit.point)) + "m";
				yield return new WaitForSeconds(rangeFinderUpdateInterval);
			}
		}
	}
}

