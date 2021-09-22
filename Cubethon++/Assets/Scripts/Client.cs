using UnityEngine;

public class Client : MonoBehaviour
{
    private PlayerController m_PlayerReciever;
    public Invoker invoker;

    //from unity documentation
    private void Awake()
    {
        //simple unity singleton pattern, ensures only newest is destroiyed
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
        m_PlayerReciever = new PlayerReciever();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if not in a replay allow for control input
        if (!GameObject.FindObjectOfType<Invoker>().inReplay)
        {
            if (Input.GetKey("a"))
            {
                Command playerCommand = new MoveLeftCommand(m_PlayerReciever);
                invoker.SetCommand(playerCommand);
                invoker.ExecuteCommand();
            }
            if (Input.GetKey("d"))
            {
                Command playerCommand = new MoveRightCommand(m_PlayerReciever);
                invoker.SetCommand(playerCommand);
                invoker.ExecuteCommand();
            }
        }
    }
}
