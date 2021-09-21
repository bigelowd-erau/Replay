
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject helpPanel;
    //called when start button on menue screen is pressed
    //starts by loading scene next in the build order
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void showHelp()
    {
        helpPanel.SetActive(true);
    }

    public void closeHelp()
    {
        helpPanel.SetActive(false);
    }
}
