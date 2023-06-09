using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject bridgeParent;
    AudioSource m_ButtonClick;
    
    bool bridgeEnabled = false;
 
    public float bridgeLife = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        m_ButtonClick = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (bridgeEnabled)
        {
            bridgeLife -= 1f *Time.deltaTime;
            if(bridgeLife <= 0)
            {
                bridgeParent.SetActive(false);
                bridgeEnabled = false;
            }
        }

        
    }
    void OnTriggerEnter(Collider other)
    {

        // Checks to see if tagged player GameObject enters trigger area around the button
        if (other.gameObject.tag == "Player")
        {
            m_ButtonClick.Play();
            
            bridgeParent.SetActive(true);
            bridgeLife = 10f;
            bridgeEnabled = true;
        }
    }
}
