using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    bool playerInRange;
    void OnTriggerEnter(Collider other)
    {

        // Checks to see if tagged player GameObject enters trigger area around the nightstand
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
