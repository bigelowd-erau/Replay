
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //the time in seconds delay before causing the scene to reset
    public float restartDelay = 1f;
    //the complete level panel
    public GameObject completeLevelScreen;
    public GameObject replayClientPrefab;
    public GameObject replayCanvasPrefab;

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
        //get if in replay through the immortal invoker
        if (!GameObject.FindObjectOfType<Invoker>().inReplay)
        { // if not in replay when next level was called, go to replay
            GameObject.FindObjectOfType<Invoker>().inReplay = true;
            //call the restart function after the defined restart delay
            Invoke("LoadReplay", restartDelay);
        }
        else
        {
            //if in replay full restart the level killing the immortals
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
        { // is in replay so go to next level after dfestroying objects saved for replay
            DestroyImmortals();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //restarts the current level
    void Restart()
    {
        //Full restart requires no immortals
        DestroyImmortals();
        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Destroys objects that were set to dont destroy on load aka immortals
    //immortals are saved for replay only then destroyed
    private void DestroyImmortals()
    {
        Destroy(GameObject.FindGameObjectWithTag("Client"));
        Destroy(GameObject.FindGameObjectWithTag("ReplayClient"));
        Destroy(GameObject.FindGameObjectWithTag("ReplayCanvas"));
    }

    //load replay of current scene
    void LoadReplay()
    {
        //create a replay client from prefab
        GameObject replayClient = Instantiate(replayClientPrefab);
        //set replay client as immortal
        DontDestroyOnLoad(replayClient);
        //create a replay canvas from prefab
        GameObject replayCanvas = Instantiate(replayCanvasPrefab);
        //set replay client as immortal
        DontDestroyOnLoad(replayCanvas);
        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
