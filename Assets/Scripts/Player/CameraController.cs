using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class CameraController : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    private Transform camTransform;
    private float xRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camTransform = Camera.main.transform;
    }

    float mouseX;
    float mouseY;
    private void Update()
    {
		mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
		mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
				
        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, camTransform.localRotation.eulerAngles.z);
        transform.Rotate(Vector3.up * mouseX);
    }
}

}
