using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //the player object's rigid body
    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysforce;
    //a sudo player rotation that is set when a new floor is touched
    public float playerRotation = 0; //io 0, 60, 120, 180
    //the calculated radial rotation
    float playerRadRot;

    private void Start()
    {
        playerRotation = 0;
    }

    // Fixedupdate is called at a fixed time interval
    void FixedUpdate()
    {
        //adds a consistent forward force to the player object
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
        //get current
        playerRadRot = Mathf.Deg2Rad * playerRotation;
        
    }

    public void MoveLeft()
    {
        rb.AddForce(-sidewaysforce * Time.deltaTime * Mathf.Cos(playerRadRot), -sidewaysforce * Time.deltaTime * Mathf.Sin(playerRadRot), 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysforce * Time.deltaTime * Mathf.Cos(playerRadRot), sidewaysforce * Time.deltaTime * Mathf.Sin(playerRadRot), 0, ForceMode.VelocityChange);
    }
}
