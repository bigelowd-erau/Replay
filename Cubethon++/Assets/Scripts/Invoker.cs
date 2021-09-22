using UnityEngine;
using System.Collections.Generic;

public class Invoker: MonoBehaviour
{
    private Command m_Command;
    //queue of all commands and their time of execution
    public Queue<CommandData> commandQueue;
    //variable for tracking if a replay invoker or not
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
        //if not in a replay, build the queue
        if (!inReplay)
        {
            //add command to queue and get the current time since level load
            CommandData commandData = new CommandData(m_Command, Time.timeSinceLevelLoad);
            commandQueue.Enqueue(commandData);
            //add new command to the command list on screen
            GameObject.FindObjectOfType<CommandDisplay>().AddCommandToDisplay(commandData.command);
        }
    }

    public void ExecuteCommand()
    {
        m_Command.Execute();
    }
}
