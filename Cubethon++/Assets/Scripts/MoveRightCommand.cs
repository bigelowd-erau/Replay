using UnityEngine;

class MoveRightCommand : Command
{
    public MoveRightCommand(PlayerController reciever) : base(reciever)
    { 
    }
    public override void Execute()
    {
        m_Reciever.MoveRight();
    }
}
