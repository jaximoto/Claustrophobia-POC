using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// Mouse movement implemented following YouTube tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
public class MouseLook : MonoBehaviour
{
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    public float mouseSensitivity;
    public float xRotation = 0f;
    float cameraPitch = 0.0f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    public Transform playerBody;
    public Camera mainCamera;
    public float zoom = 45f;
    bool lockCursor = true;
    Ray ray;
    public float maxRayDistance = 10;
    public LayerMask layertoHit;
    Vector3 middleOfCamera = new Vector3(0.5f, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        // Removes mouse from being visible on the scene; sometimes buggy for me
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();

        // Zoom Feature:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.fieldOfView -= zoom;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            mainCamera.fieldOfView += zoom;
        }
        CheckForColliders();

    }
    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta,  ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        // Limits player view to make movement a bit easier
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
       // cameraPitch = Mathf.Clamp(cameraPitch, -45.0f, 45.0f);

        transform.localEulerAngles = Vector3.right * cameraPitch;
        playerBody.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);


    }

    void CheckForColliders()
    {
        ray = Camera.main.ViewportPointToRay(middleOfCamera);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, layertoHit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               // Debug.Log("E was hit correctly!");
                if (hit.collider.gameObject.TryGetComponent(out Keys keyScript))
                {
                    keyScript.KeyPickUp();
                    //Debug.Log("KeyPickUp() was called!");
                }
                else if (hit.collider.gameObject.TryGetComponent(out KeyTrigger keyTriggerScript))
                {
                    keyTriggerScript.KeyPickUp();
                    //Debug.Log(keyTriggerScript.ToString() + "was found");
                }
            }
            //Debug.Log(hit.collider.gameObject.name + " was hit!");
        }
    }
}
