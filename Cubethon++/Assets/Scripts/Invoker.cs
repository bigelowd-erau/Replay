using UnityEngine;
using System.Collections.Generic;

public class Invoker: MonoBehaviour
{
    private Command m_Command;
    public Queue<Command> commandQueue;
    public CommandDisplay commandDisplay;

    public Invoker()
    {
        commandQueue = new Queue<Command>();
    }

    public void SetCommand(Command command)
    {
        m_Command = command;
        commandQueue.Enqueue(m_Command);
        commandDisplay.AddCommandToDisplay(m_Command); ;
    }

    public void ExecuteCommand()
    {
        m_Command.Execute();
    }
}
