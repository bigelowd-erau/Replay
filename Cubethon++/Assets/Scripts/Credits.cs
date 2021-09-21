using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    //quit function that is called when quit button is pressed on credits scenes
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
