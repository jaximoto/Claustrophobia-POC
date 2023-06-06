using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    //public Transform player;
    
    GameObject key;
    
    public AudioSource m_PickUp; //Reference to audio in audio prefab: each key has its own audio gameObject
    private bool m_Play = false;
    

    private GameObject text;

    void Start()
    {
        key = this.gameObject;
        //m_PickUp = GetComponent<AudioSource>();
        
        
    }
    /*
    void OnTriggerEnter(Collider other)
    {

        // Checks to see if tagged player GameObject enters trigger area around the nightstand

        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    */
    void Update()
    {
        // if player is in trigger range and text hasn't yet been displayed,
        // call to display Pick Up Object text
        
        /*
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!m_Play)
                {
                    m_PickUp.Play();
                    m_Play = true;
                }
                KeyPickUp();
                
            }
        }
        */
    }

    public void KeyPickUp()
    {
        if (!m_Play)
        {
            m_PickUp.Play();
            m_Play = true;
            Destroy(key);
        }
        
    }
}
