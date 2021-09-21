using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float offset;

    // Update is called once per frame
    void Update()
    {
        //set the camera to the middle of the game and to follow behind player at a specified distance
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset);
    }
}
