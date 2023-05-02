using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
  
    public Transform player;
    public GameObject FloatingText;
    public GameObject key;

    bool playerInRange;
    bool textDisplayed = false;

    private GameObject text;

    void OnTriggerEnter(Collider other)
     {
 
         // Checks to see if tagged player GameObject enters trigger area around the nightstand
         if (other.gameObject.tag == "Player")
         {
             playerInRange = true;
         }
     }
 
    void Update()
     {
         // if player is in trigger range and text hasn't yet been displayed,
         // call to display Pick Up Object text
         if (playerInRange && !textDisplayed)
         {
            DisplayFloatingText();
         }

         if (playerInRange && textDisplayed)
         {
            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyPickUp();
                Destroy(text);
            }
         }
 
     }
 

    void DisplayFloatingText()
    {
        // turns off call in update to display text; otherwise this function is called indefinitely
        textDisplayed = true;

        Vector3 offset = new Vector3 (1f, 0.5f, 0f);

        // instantiate the prefab
        // instantiation has specific rotation and position for the key in this scene -- will have to fix for other levels
        text = Instantiate(FloatingText, key.transform.position + offset, transform.rotation * Quaternion.Euler (180f, -60f, 180f));

        // The font must be large to be rendered clearly. This call shrinks text to necessary size in scene
        text.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    void KeyPickUp()
    {
        Destroy(key);
    }

}
