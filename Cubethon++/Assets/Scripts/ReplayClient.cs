using UnityEngine;

public class ReplayClient : MonoBehaviour
{
    //public Invoker invoker;
    private CommandData currentCommand;

    public void Awake()
    {
        //set the first command when created
        //sets commands by popping the first commandData off the invoker's queue
        currentCommand = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();
    }

    public void FixedUpdate()
    {
        //if the current time running has gotten to (or slightly passed) when the command wa scalled initially
        if (Time.timeSinceLevelLoad >= currentCommand.timeOfExecution)
        {
            //if there is a command ion the queue
            if (GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Count > 0)
            {
                //invoker.SetCommand();
                GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().SetCommand(currentCommand.command);
                //Invoker.Execute();
                GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().ExecuteCommand();
                //get the next command
                currentCommand = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();
            }
        }
    }
}
