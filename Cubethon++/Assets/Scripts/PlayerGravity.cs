using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private void Start()
    {
        ChangeGravity(0);
    }

    //changes grabity to be in the direction of the current floor
    public void ChangeGravity(float rotation)
    {
        rotation = Mathf.Deg2Rad * rotation;
        Physics.gravity = new Vector3(20f*Mathf.Sin(rotation), -20f * Mathf.Cos(rotation), 0);
    }
}
