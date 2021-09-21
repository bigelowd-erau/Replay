using UnityEngine;

public class CommandData
{
    public Command command { get; }
    public float timeOfExecution { get;}

    public CommandData (Command command, float time)
    {
        this.command = command;
        this.timeOfExecution = time;
    }
}
