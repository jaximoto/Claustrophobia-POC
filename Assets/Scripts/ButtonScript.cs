using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private GameObject wall1;
    private GameObject wall2;
    AudioSource m_ButtonClick;
    bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        wall1 = GameObject.Find("Dresser Wall1");
        wall2 = GameObject.Find("Dresser Wall2");
        m_ButtonClick = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

        // Checks to see if tagged player GameObject enters trigger area around the button
        if (other.gameObject.tag == "Player")
        {
            m_ButtonClick.Play();
            playerInRange = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            Destroy(wall1);
            Destroy(wall2);
        }
        
    }
}
