using UnityEngine;

public class PlayerReciever : PlayerController
{
    public PlayerMovement pm;

    public PlayerReciever(PlayerMovement pm)
    {
        this.pm = pm;
    }
    public override void MoveLeft()
    {
        pm.MoveLeft();
        Debug.Log("Move Left");
    }

    public override void MoveRight()
    {
        pm.MoveRight();
        Debug.Log("Move Right");
    }
}
