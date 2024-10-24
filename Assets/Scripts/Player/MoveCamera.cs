﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; 

    private float xRotation = 0f;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _MoveCamera(mouseX, mouseY);
    }

    public void _MoveCamera(float _mouseX, float _mouseY)
    {
       
        xRotation -= _mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
