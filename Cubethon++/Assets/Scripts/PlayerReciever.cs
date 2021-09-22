using UnityEngine;

public class PlayerReciever : PlayerController
{
    public PlayerReciever()
    {
    }
    public override void MoveLeft()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveLeft();
        //pm.MoveLeft();
        //Debug.Log("Move Left");
    }

    public override void MoveRight()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveRight();
        //pm.MoveRight();
        //Debug.Log("Move Right");
    }
}
