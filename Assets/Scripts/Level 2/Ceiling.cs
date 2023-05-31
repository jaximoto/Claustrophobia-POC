using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ceiling : MonoBehaviour
{
    // Start is called before the first frame update
    //public TextMeshProUGUI countdownText;
    //private float startingTime;
    public float delay = 0.0f;
    public float speed = 1.0f;
    public string level;
    private float startTime;
    private float currentTime;
    private Transform fallingCeiling;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        fallingCeiling = GetComponent<Transform>();

        // startingTime = Time.Now();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.timeSinceLevelLoad;
        //Debug.Log(currentTime);
        if (startTime + currentTime > delay)
        {
            MoveCeiling();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Restart level
            SceneManager.LoadScene(level);
        }
    }
    void MoveCeiling()
    {
        fallingCeiling.position = fallingCeiling.position + ((Vector3.down * speed) * Time.deltaTime);
    }
    }
