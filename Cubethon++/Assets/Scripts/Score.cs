using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //the transform(location, rotation) information of the player
    public Transform player;
    public Text scoreText;
    // Update is called once per frame
    void Update()
    {   
        //set the score text to 1/10 the player's z position
        //and convert to string with a ecimal accuracy of 0 (no decimal places)
        scoreText.text = (player.position.z/10).ToString("0");
    }
}
