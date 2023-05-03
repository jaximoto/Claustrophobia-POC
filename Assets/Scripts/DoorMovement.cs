using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public Collider outside;
    public GameObject Door;
    private Quaternion DoorOpen;
    private Quaternion DoorClosed;
    private float rotate_speed = 0.1f;

    void OnTriggerEnter(Collider other)
     {
 
         // Checks to see if tagged player GameObject enters trigger area around the nightstand
         if (other.gameObject.tag == "Player")
         {
            if (GameObject.Find("rust_key") == null)
            {

                // 01_low is the door without the frame
                Door = GameObject.Find("01_low");
                DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 90, 0);
                DoorClosed = Door.transform.rotation;

                Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * rotate_speed);
                outside.enabled = true;
            }
         }
     }

   public void OpenDoor()
   {
       gameObject.SetActive(false);
   }
}
