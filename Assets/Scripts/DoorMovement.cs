using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // public Collider outside;
    public GameObject Door;
    public GameObject Barrier;
    private bool Locked = true;
    private Quaternion DoorOpen;
    private Quaternion DoorClosed;
    private float rotate_speed = 0.1f;
    AudioSource m_DoorOpen;
    
    void Start () 
    {
        m_DoorOpen = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        // if the door is not already unlocked so we don't keep playing the door sound effect
        if (Locked) {
            // Checks to see if tagged player GameObject enters trigger area around the nightstand
            if (other.gameObject.tag == "Player")
            {
                if (GameObject.Find("rust_key") == null)
                {

                    // 01_low is the door without the frame
                    Door = GameObject.Find("01_low");
                    Barrier = GameObject.Find("Locked Barrier");
                    DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 90, 0);
                    DoorClosed = Door.transform.rotation;
                    // Play sound effect
                    m_DoorOpen.Play();
                    Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * rotate_speed);
                    Barrier.SetActive(false);
                    Locked = false;
                    // outside.enabled = true;
                }
            }
        }
    }

    // public void OpenDoor()
    // {
    //     gameObject.SetActive(false);
    // }
}
