using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // public Collider outside;
    public GameObject Door; // should be "01_low"
    public int DoorNumber;
    public GameObject LoadingScreenUI;
    public GameObject Barrier; // should be "Locked Barrier"
    private GameObject Key; // should be "rust_key"
    private bool Locked = true;
    private Quaternion DoorOpen;
    private Quaternion DoorClosed;
    //private float rotate_speed = 0.1f;
    private AudioSource m_DoorOpen;

    void Start()
    {
        m_DoorOpen = GetComponent<AudioSource>();
        Barrier = GameObject.FindWithTag(String.Format("Barrier{0}", DoorNumber));
        Key = GameObject.FindWithTag(String.Format("Key{0}", DoorNumber));

    }

    void OnTriggerEnter(Collider other)
    {
        // if the door is not already unlocked so we don't keep playing the door sound effect
        if (Locked)
        {
            // Checks to see if tagged player GameObject enters trigger area around the nightstand
            if (other.gameObject.tag == "Player")
            {
                if (Key == null)
                {
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor()
    {
        DoorClosed = Door.transform.rotation;
        DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 0, 0);
        // Play sound effect
        m_DoorOpen.Play();
        //Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * rotate_speed);
        //Debug.Log(Door.transform.rotation);
        if (DoorNumber == 2)
        {
            LoadingScreenUI.SetActive(true);
        }
        Barrier.GetComponent<BoxCollider>().enabled = false;
        Locked = false;
    }
}
