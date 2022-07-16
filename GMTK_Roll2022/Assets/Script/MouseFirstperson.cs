using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFirstperson : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float xRotation;
    public float mouseSensitivity;
    public Transform playerBody;
    
    void Start()
    {
        
    }

    void Update()
    {
        mouse_fps();
    }

    void mouse_fps()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
