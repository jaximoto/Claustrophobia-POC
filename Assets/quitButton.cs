using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class quitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
