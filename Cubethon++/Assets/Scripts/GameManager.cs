
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    //the time in seconds delay before causing the scene to reset
    public float restartDelay = 1f;
    //the complete level panel
    public GameObject completeLevelScreen;
    public GameObject replayClientPrefab;
    bool inReplay = false;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    //called when the end object is triggered
    public void CompleteLevel()
    {
        //enables the level complete panel
        //causing the panel to overlay the game
        completeLevelScreen.SetActive(true);
    }
    
    //Called when the player loses the level
    //hits obstacle or falls off map
    public void EndGame()
    {
        //checks game has not previously quit    
        if (!GameObject.FindObjectOfType<Invoker>().inReplay)
        {
            GameObject.FindObjectOfType<Invoker>().inReplay = true;
            //call the restart function after the defined restart delay
            Invoke("LoadReplay", restartDelay);
        }
        else
        {
            Invoke("Restart", restartDelay);
        }

    }

    //Is called when the end of level is reached
    public void NextLevel()
    {
        //get if in replay through the immortal invoker
        if (!GameObject.FindObjectOfType<Invoker>().inReplay)
        { // if not in replay when next level was called, go to replay
            GameObject.FindObjectOfType<Invoker>().inReplay = true;
            //call the loadReplay function after the defined restart delay
            Invoke("LoadReplay", restartDelay);
        }
        else
        {
            DestroyImmortals();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //restarts the current level
    void Restart()
    {
        DestroyImmortals();
        inReplay = false;
        Debug.Log("Stuff destroyed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Destroys objects that were set to dont destroy on load
    private void DestroyImmortals()
    {
        Destroy(GameObject.FindGameObjectWithTag("Client"));
        Destroy(GameObject.FindGameObjectWithTag("ReplayClient"));
    }

    void LoadReplay()
    {
        GameObject replayClient = Instantiate(replayClientPrefab);
        DontDestroyOnLoad(replayClient);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EndReplay()
    {
        Destroy(GameObject.FindGameObjectWithTag("Client"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
