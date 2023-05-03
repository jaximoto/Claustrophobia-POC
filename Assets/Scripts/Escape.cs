using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        // Checks to see if tagged player GameObject enters trigger area around the nightstand
        if (other.gameObject.tag == "Player")
        {
           // Player escaped room
           Application.Quit();
            Debug.Log("game ended");
        }
    }
   
}
