using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
  public Transform player;
  //public Transform FloatingText;
  public GameObject clock;
  bool playerInRange;
  public GameObject FloatingText;
  bool textDisplayed = false;
  private GameObject text;
	//public bool realTime=true;
  public int hour = 0;
  public int minutes = 0;
  public int seconds = 0;
  public bool realTime = false;

  //public int targetHour = 12;
  public bool puzzleStatus; // has the player has set the time correctly??
  public GameObject HintText;
  private GameObject hint;
  bool hintDisplayed = false;

	public GameObject pointerSeconds;
  public GameObject pointerMinutes;
  public GameObject pointerHours;

  //-- time speed factor
  public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster
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
      playerInRange = false;
      puzzleStatus = false; //ie, puzzle not yet solved
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
      if(!textDisplayed)
      {
        DisplayText();
      }
      if(Input.GetKeyDown(KeyCode.R))
      {
        AddTime();
      }
      if(Input.GetKeyDown(KeyCode.T))
      {
        SubTime();
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

    // now check if the player has set the time correctly, +/-10 minutes
    // first check if the minute hand is >55 or <05
    if((minutes) >=55){
      if((hour == 11)||(hour == 23)){
        puzzleStatus = true;
      }
    } else if(minutes <= 5) {
      if((hour == 12) || (hour == 24))
      {
        puzzleStatus = true;
      }
    }
    if(puzzleStatus)
    {
      hintDisplayed = true;
      DisplayHint();
      Destroy(text);
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
      minutes += 10;
      if(minutes > 60){
        minutes = 0;
        hour++;
        if(hour >= 24){
          hour = 0;
        }
      }
  }

  void SubTime(){
    minutes -= 10;
    if (minutes < 0)
    {
      minutes = 60 - minutes;
      hour--;
      if(hour==0)
      {
        hour = 24;
      }
    }
  }




  void DisplayText()
  {
    if(!hintDisplayed)
    {


      textDisplayed = true;
      Vector3 offset = new Vector3(1f, 0.5f, 0f);
      //text = Instantiate
      // instantiate the prefab
      // instantiation has specific rotation and position for the key in this scene -- will have to fix for other levels
      text = Instantiate(FloatingText, clock.transform.position + offset, transform.rotation * Quaternion.Euler (90f, -60f, 180f));

      // The font must be large to be rendered clearly. This call shrinks text to necessary size in scene
      text.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }
  }

  void DisplayHint()
  {
    if(text)
    {
      Destroy(text);
    }
    hintDisplayed = true;
    Vector3 offset = new Vector3(1f, 0.5f, 0f);
    hint = Instantiate(HintText, clock.transform.position + offset, transform.rotation * Quaternion.Euler (90f, -60f, 180f));
  }

}
