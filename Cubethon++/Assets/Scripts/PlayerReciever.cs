using UnityEngine;

public class PlayerReciever : PlayerController
{
    public override void MoveLeft()
    {
        //Find the player object and find th emovement script then call move left
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveLeft();
    }

    public override void MoveRight()
    {
        //Find the player object and find th emovement script then call move right
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveRight();
    }
}
