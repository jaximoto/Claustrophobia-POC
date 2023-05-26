using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CeilingTimer : MonoBehaviour
{
    public float levelTimeSeconds = 10f;
    //public TextMeshProUGUI countdownText;
    //private float startingTime;
    public GameObject CeilingGO;
    private float Ceiling;
    private float Distance;
    private float NewCeilingHeight;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        Ceiling = CeilingGO.transform.position[1];
        // difference between ceiling height and player height
        Distance = Ceiling - 2.0f;

        // startingTime = Time.Now();
    }

    // Update is called once per frame
    void Update()
    {
        // lerping ceiling height based on time in game
        currentTime = Time.deltaTime;
        float ratio = currentTime / levelTimeSeconds;
        NewCeilingHeight =  ratio * Distance;
        //Debug.Log(String.Format("Ceiling height lowered by: {0}", NewCeilingHeight));
        //CeilingGO.transform.position = Ceiling - NewCeilingHeight;
        CeilingGO.transform.position = CeilingGO.transform.position + (Vector3.down * NewCeilingHeight);
        //Debug.Log(CeilingGO.transform.position);
        if (levelTimeSeconds <= Time.realtimeSinceStartup)
        {
            currentTime = 0;
            Application.Quit();
            Debug.Log("ended");
        }
    }
}
