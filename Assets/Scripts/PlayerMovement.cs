using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 8f;

    // Start is called before the first frame update
/*    void Start()
    {
        // Might need to place player in scene depending on placement of other assets
    }
*/

    // Update is called once per frame
    void Update()
    {
        // Horizontal and Vertical are the default Unity definitions for this input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
