using UnityEngine;
using System.Collections.Generic;

public class Invoker: MonoBehaviour
{
    private Command m_Command;
    public Queue<CommandData> commandQueue;
    public bool inReplay;

    //public CommandDisplay commandDisplay;

    public Invoker()
    {
        commandQueue = new Queue<CommandData>();
        inReplay = false;
    }

    public void SetCommand(Command command)
    {
        m_Command = command;
        CommandData commandData = new CommandData(m_Command, Time.timeSinceLevelLoad);
        if (!inReplay)
        {
            commandQueue.Enqueue(commandData);
            GameObject.FindObjectOfType<CommandDisplay>().AddCommandToDisplay(commandData.command);
        }
    }

    public void ExecuteCommand()
    {
        m_Command.Execute();
    }
}
