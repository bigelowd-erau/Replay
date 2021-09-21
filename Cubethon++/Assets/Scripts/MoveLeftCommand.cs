using UnityEngine;

class MoveLeftCommand : Command
{
    public MoveLeftCommand(PlayerController reciever) : base(reciever)
    {
    }
    public override void Execute()
    {
        m_Reciever.MoveLeft();
    }
}
