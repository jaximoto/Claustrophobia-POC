using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Might need to place player in scene depending on placement of other assets
        m_AudioSource = GetComponent<AudioSource>();
       
    }

    void FixedUpdate()
    {
        // float horizontal = Input.GetAxis ("Horizontal");
        // float vertical = Input.GetAxis ("Vertical");
        // bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        // bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        // bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        // if (isWalking)
        // {
        //     if (!m_AudioSource.isPlaying)
        //     {
        //         m_AudioSource.Play();
        //     }
        // }
        // else
        // {
        //     m_AudioSource.Stop ();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Horizontal and Vertical are the default Unity definitions for this input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately (x, 0f);
        bool hasVerticalInput = !Mathf.Approximately (z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
