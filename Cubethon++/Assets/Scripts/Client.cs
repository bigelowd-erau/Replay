using UnityEngine;

public class Client : MonoBehaviour
{
    private PlayerController m_PlayerReciever;
    public PlayerMovement pm;
    public Invoker invoker;

    //from unity documentation
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Client");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerReciever = new PlayerReciever(pm);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            Command playerCommand = new MoveLeftCommand(m_PlayerReciever);
            //Invoker invoker = new Invoker();

            invoker.SetCommand(playerCommand);
            invoker.ExecuteCommand();
        }
        if (Input.GetKey("d"))
        {
            Command playerCommand = new MoveRightCommand(m_PlayerReciever);
            //Invoker invoker = new Invoker();

            invoker.SetCommand(playerCommand);
            invoker.ExecuteCommand();
        }
    }
}
