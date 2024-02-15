using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] float mouseSesnsitivity;
    [SerializeField] float xRotation = 0f;
    [SerializeField] Transform playerBody;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CameraLook();
    }

    private void CameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSesnsitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSesnsitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
