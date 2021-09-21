
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
        if (gameHasEnded == false)
        {
            //set game as ended
            gameHasEnded = true;
            //call the restart function after the defined restart delay
            //Invoke("Restart", restartDelay);
            Invoke("LoadReplay", restartDelay);
        }

    }

    //reloads the current level
    void Restart()
    {
        //Destroy(GameObject.FindGameObjectWithTag("Client"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadReplay()
    {
        //FindObjectOfType<Client>().enabled = true;
        Debug.Log(FindObjectOfType<Client>().invoker.commandQueue.Count );
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
