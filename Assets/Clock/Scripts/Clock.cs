using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
  public Transform player;
  public Transform FloatingText;
  public GameObject clock;
  bool playerInRange;
  bool textDisplayed = false;
  private GameObject text;
	//public bool realTime=true;
  public int hour = 0;
  public int minutes = 0;
  public int seconds = 0;
  public bool realTime = false;

	public GameObject pointerSeconds;
  public GameObject pointerMinutes;
  public GameObject pointerHours;

  //-- time speed factor
  //public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster
  public float clockSpeed = 2.0f;
  //-- internal vars
  float msecs=0;

  void Start()
  {
  	//-- set real time
    /*
  	if (realTime)
  	{
  		hour=System.DateTime.Now.Hour;
  		minutes=System.DateTime.Now.Minute;
  		seconds=System.DateTime.Now.Second;
  	} else {
    */
      hour = 9;
      minutes = 0;
      seconds = 0;

      if(playerInRange)
      {
        if(!textDisplayed)
        {
          //DisplayText();
        } else {
          if(Input.GetKeyDown(KeyCode.R))
          {
            AddTime();
          }
          //if(Input.GetKeyDown(KeyCode.T))
          //{
          //  SubTime();
          //}
        }
      }
  }
  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      playerInRange = true;
    }
  }

  void Update()
  {
    if(playerInRange)
    {
      //if(!textDisplayed)
      //DisplayText();
      if(Input.GetKeyDown(KeyCode.R))
      {
        AddTime();
        //minutes += 15;
      }
    }

    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;
    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }

    //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

  }

  void AddTime()
  {
      minutes += 15;
      if(minutes > 60){
        minutes = 0;
        hour++;
        if(hour >= 24){
          hour = 0;
        }
      }

    /*
    void DisplayText()
    {
      textDisplayed = true;
      Vector3 offset = new Vector3(1f, 0.5f, 0f);
      //text = Instantiate
    }
    */
  }
}
