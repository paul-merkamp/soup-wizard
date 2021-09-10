﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	
	public float xMouseSensitivity = 100f;
	public float yMouseSensitivity = 100f;
	
	public Transform playerBody;
	
	public bool disabled = false;
	
	float xRotation = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		if (!disabled){
			float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * Time.deltaTime;
			
			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);
			
			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * mouseX);
		}
    }
}
