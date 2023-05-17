using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mouse movement implemented following YouTube tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public float xRotation = 0f;
    
    public Transform playerBody;
    public Camera mainCamera;
    public float zoom = 45f;
    // Start is called before the first frame update
    void Start()
    {
        // Removes mouse from being visible on the scene; sometimes buggy for me
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse X/Y is a Unity default definition for mouse location input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // -= prevents weird rotation
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotation logic from tutorial
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Zoom Feature:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.fieldOfView -= zoom;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            mainCamera.fieldOfView += zoom;
        }

    }
}
