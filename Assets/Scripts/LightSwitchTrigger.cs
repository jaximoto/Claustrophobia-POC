using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchTrigger : MonoBehaviour
{
    public Transform player;
    public GameObject FloatingText;
    public GameObject lightSwitch;
    AudioSource m_PickUp;
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
            Debug.Log("Player in range");
         }

         if (playerInRange && textDisplayed)
         {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(text);
                turnOffLight();
            }
         }
 
     }
 

    void DisplayFloatingText()
    {
        // turns off call in update to display text; otherwise this function is called indefinitely
        textDisplayed = true;

        Vector3 offset = new Vector3 (1f, 0.5f, 0f);

        // instantiate the prefab
        // instantiation has specific rotation and position for the switch in this scene 
        text = Instantiate(FloatingText, lightSwitch.transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f));

        // The font must be large to be rendered clearly. This call shrinks text to necessary size in scene
        text.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
    }

    void turnOffLight()
    {
        Debug.Log("light off");
    }

}
