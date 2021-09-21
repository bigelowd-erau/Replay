
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerGravity playerGravity;
    public Client client;

    //when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        //iff the collider is a floor
        if (collision.collider.tag == "Floor")
        {
            //if the player's rotation is not the same as the floor
            //each floor is set at 60 degree intervals
            if (movement.playerRotation != collision.collider.transform.rotation.z)
            {
                //set player rotation to the floor's rotation
                movement.playerRotation = collision.collider.transform.rotation.eulerAngles.z;
                //change the gravity towards the direction of the players new rotation.
                playerGravity.ChangeGravity(movement.playerRotation);
            }
        }
        //if the object collided into has a tag of obstacle
        else if (collision.collider.tag == "Obstacle")
        {
            //disable player movment script
            movement.enabled = false;
            client.enabled = false;
            collision.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
