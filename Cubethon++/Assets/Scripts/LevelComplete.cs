using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //will load the nexet level in the build order
    public void LoadNextLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Client"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
