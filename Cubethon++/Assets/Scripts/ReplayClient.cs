using UnityEngine;

public class ReplayClient : MonoBehaviour
{
    //public Invoker invoker;
    private CommandData currentCommand;

    public void Awake()
    {

        currentCommand = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();
        //invoker = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>(); ;
        //SetCurrentCommand();
        /*foreach (CommandData cd in GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue)
        {
            Debug.Log(cd.command.ToString());
        }*/
    }

    public void FixedUpdate()
    {
        //current time running has gotten to (or slightly passed) when the command wa scalled initially
        if (Time.timeSinceLevelLoad >= currentCommand.timeOfExecution)
        {
            if (GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Count > 0)
            {
            
                GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().SetCommand(currentCommand.command);
                //invoker.SetCommand(currentCommand.command);
                GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().ExecuteCommand();
                currentCommand = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();

                //invoker.ExecuteCommand();
                //SetCurrentCommand();
                //if (!SetCurrentCommand())
                //FindObjectOfType<GameManager>().Restart();
            }
        }
    }

    /*private void SetCurrentCommand()
    {
        int commandsLeft = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Count;
        Debug.Log(commandsLeft);
        if (commandsLeft > 0)
        {
            currentCommand = GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();
            //GameObject.FindGameObjectWithTag("Client").GetComponent<Invoker>().commandQueue.Dequeue();
        } else
        {
            
        }
    }*/
}
