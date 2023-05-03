using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTimer : MonoBehaviour
{
    public float startingTime = 10f;
    public TextMeshProUGUI countdownText;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        int minutesInt = (int)(currentTime / 60);
        int secondsInt = (int)(currentTime % 60);
        countdownText.text = minutesInt.ToString() + ":" + secondsInt.ToString();

        if (minutesInt <= 0)
        {
            countdownText.color = Color.red;
        }

        if (secondsInt <= 0)
        {
            currentTime = 0;
        }
    }
}
