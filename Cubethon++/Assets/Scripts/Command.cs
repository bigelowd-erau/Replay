using UnityEngine;

public abstract class Command
{
    protected PlayerController m_Reciever;

    public Command(PlayerController reciever)
    {
        m_Reciever = reciever;
    }

    public abstract void Execute();
}
