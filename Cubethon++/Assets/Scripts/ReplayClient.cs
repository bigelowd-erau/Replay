using UnityEngine;

public class ReplayClient : MonoBehaviour
{
    public Invoker invoker;
    private CommandData currentCommand;

    public void Awake()
    {
        SetCurrentCommand();
    }

    public void Update()
    {
        //current time running has gotten to (or slightly passed) when the command wa scalled initially
        if (Time.timeSinceLevelLoad >= currentCommand.timeOfExecution)
        {
            invoker.SetCommand(currentCommand.command);
            invoker.ExecuteCommand();
            if (!SetCurrentCommand())
                FindObjectOfType<GameManager>().EndGame();
        }
    }

    private bool SetCurrentCommand()
    {
        if (invoker.commandQueue.Count > 0)
        {
            currentCommand = invoker.commandQueue.Dequeue();
            return true;
        } else
        {
            return false;
        }
    }
}
