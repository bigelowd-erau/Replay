using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object that when player goes through triggers level completion
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //when player enters the object
    private void OnTriggerEnter(Collider other)
    {
        gameManager.CompleteLevel();
    }
}
