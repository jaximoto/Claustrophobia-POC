using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchTrigger : MonoBehaviour
{
    public Transform player;
    public Light room_lighting;
    public GameObject FloatingTextLightOff;
    public GameObject FloatingTextLightOn;
    public GameObject lightSwitch;
    GameObject hintText;
    AudioSource m_Switch;
    bool playerInRange;
    bool textDisplayed = false;
    
    bool lightOff = false;
    
    
    private GameObject textOff;
    private GameObject textOn; 

    void Start() {
        m_Switch = lightSwitch.GetComponent<AudioSource>();
        hintText = GameObject.Find("Hint");
        hintText.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
     {
 
         // Checks to see if tagged player GameObject enters trigger area around the nightstand
         if (other.gameObject.tag == "Player")
         {
             playerInRange = true;
         }
     }

     void OnTriggerExit(Collider other)
     {
 
         // Checks to see if tagged player GameObject enters trigger area around the nightstand
         if (other.gameObject.tag == "Player")
         {
             playerInRange = false;
         }
     }
 
    void Update()
     {
         // if player is in trigger range and text hasn't yet been displayed,
         // call to display Pick Up Object text
         if (playerInRange && !textDisplayed)
         {
            DisplayFloatingOffText();
            Debug.Log("Player in range");
         }

        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !lightOff)
            {
                Destroy(textOff);
                turnOffLight();

            }

            if (Input.GetKeyDown(KeyCode.F) && lightOff)
            {
                Destroy(textOn);
                turnOnLight();
            }
        }
 
     }
 

    // function to display "press e to turn off" text
    void DisplayFloatingOffText()
    {
        // turns off call in update to display text; otherwise this function is called indefinitely
        textDisplayed = true;

        Vector3 offset = new Vector3 (1f, 0.5f, 0f);

        // instantiate the prefab
        // instantiation has specific rotation and position for the switch in this scene 
        textOff = Instantiate(FloatingTextLightOff, lightSwitch.transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f));

        // The font must be large to be rendered clearly. This call shrinks text to necessary size in scene
        textOff.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
    }

   void DisplayFloatingOnText()
    {
        Vector3 offset = new Vector3 (1f, 0.5f, 0f);

        // instantiate the prefab
        // instantiation has specific rotation and position for the switch in this scene 
        textOn = Instantiate(FloatingTextLightOn, lightSwitch.transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f));

        // The font must be large to be rendered clearly. This call shrinks text to necessary size in scene
        textOn.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
    } 

    void turnOffLight()
    {
        m_Switch.Play();
        room_lighting.enabled = false;
        hintText.SetActive(true);
        //room_lighting.intensity = 0f;
        Debug.Log("Light off");
        DisplayFloatingOnText();
        lightOff = true;
    }

    void turnOnLight()
    {
        m_Switch.Play();
        hintText.SetActive(false);
        room_lighting.enabled = true;
        //room_lighting.intensity = 1f;
        Debug.Log("Light on");
        DisplayFloatingOffText();
        lightOff = false;
    }


}
